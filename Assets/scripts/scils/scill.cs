using UnityEngine;

namespace scils
{
    public class scill : MonoBehaviour
    {
        public GameObject Sword;
        public Vector3 spawnOffset = Vector3.zero;

        public void SpawnSword(float size, float r)
        {
            if (Sword == null)
            {
                Debug.LogError("Object to spawn is not assigned!");
                return; 
            }

            Vector3 spawnPosition = transform.position + spawnOffset;
            Vector3 newScale = new Vector3(size, r, 1f);
            GameObject spawnedSword = Instantiate(Sword, spawnPosition, Quaternion.identity);
            spawnedSword.transform.localScale = newScale;
            // InvokeRepeating("DespawnSword",2f,0f); 

        }
            // void DespawnSword()
            // {
            // Destroy(Sword);
            // }
    }
}