using UnityEngine;
using scils;
using System.Collections;

public class wasd : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;

    public bool[] ActiveSkills = new bool[2];
    public scill skillScript; // Добавлена публичная переменная для ссылки на scill

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found!");
        }
        // Получаем ссылку на скрипт scill.  Важно это сделать в Start() после инициализации всех объектов
        if (skillScript == null) {
          skillScript = GetComponent<scill>(); // Пытаемся найти скрипт на том же объекте
          if (skillScript == null) {
            Debug.LogError("scill script not found!");
          }
        }
    }

    private bool isSpawning = false;

    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        rb.linearVelocity = new Vector2(horizontalMove * speed,  verticalMove * speed); 

        // if (ActiveSkills[0] && !isSpawning){
        // isSpawning = true;
        // InvokeRepeating("SpawnSwordPeriodically", 0f, 2f); // Вызов через 0 секунд, повторяющийся каждые 2 секунды
        // } 
        // else if (!ActiveSkills[0] && isSpawning) {
        // CancelInvoke("SpawnSwordPeriodically"); // Остановка, если ActiveSkills[0] false
        // isSpawning = false;
        // }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.LogError("коснулся врага");
        }
    }


// void SpawnSwordPeriodically()
// {
//     skillScript.SpawnSword(1f, 1f);
// }
}