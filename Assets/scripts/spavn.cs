using UnityEngine;

public class spavn : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float spawnRate = 2f;
    public float spawnDistance = 5f;
    public int maxEnemies = 100; // Максимальное количество врагов на сцене

    private Camera mainCamera;
    private int currentEnemies = 0;


    void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("SpawnEnemy", 0f, spawnRate);
    }

    void SpawnEnemy()
    {
        if (currentEnemies >= maxEnemies) return;

        Vector3 spawnPosition = GetSpawnPositionOutsideCamera();
        if (spawnPosition != Vector3.zero) {
            Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
            currentEnemies++;
        }
    }

    Vector3 GetSpawnPositionOutsideCamera()
    {
        float cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float cameraHalfHeight = mainCamera.orthographicSize;
        float cameraXPos = mainCamera.transform.position.x;
        float cameraYPos = mainCamera.transform.position.y;

        int attempts = 10; // Максимальное количество попыток найти точку вне камеры
        while (attempts-- > 0) {
          float randomX = Random.Range(-cameraHalfWidth - spawnDistance, cameraHalfWidth + spawnDistance);
          float randomY = Random.Range(-cameraHalfHeight - spawnDistance, cameraHalfHeight + spawnDistance);
          Vector3 testPos = new Vector3(randomX, randomY, 0);

          // Проверка, находится ли точка за пределами камеры
          if (!IsInsideCamera(testPos)) {
              return testPos;
          }
        }
        return Vector3.zero; // Не удалось найти позицию за пределами камеры после нескольких попыток

    }

    bool IsInsideCamera(Vector3 position)
    {
        float cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float cameraHalfHeight = mainCamera.orthographicSize;
        float cameraXPos = mainCamera.transform.position.x;
        float cameraYPos = mainCamera.transform.position.y;

        return Mathf.Abs(position.x - cameraXPos) < cameraHalfWidth && Mathf.Abs(position.y - cameraYPos) < cameraHalfHeight;
    }
}
