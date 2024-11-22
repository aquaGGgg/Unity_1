using UnityEngine;

public class vrag : MonoBehaviour
{
     

    public Transform target;
    public float speed = 2f;
    public int hp; 

    void Start(){
            if (target == null){
                target = GameObject.FindGameObjectWithTag("Player").transform;

                if (target == null){
                   Debug.LogError("Player not found!  Make sure you have a GameObject tagged 'Player'.");
                }
        }
    }
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;
        if(hp==0){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player"))
        speed *=-2;
    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player"))
        speed *=-0.5f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("scord")){
            hp-=1;
        }
    }
    
}
