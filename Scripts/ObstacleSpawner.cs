using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnY = -3.5f;
    public float offsetFromRight = 2f;
    public Camera mainCamera;

    private void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            SpawnObstacle();
            float waitTime = Random.Range(3f, 5f);
            yield return new WaitForSeconds(waitTime);
        }
    }

    void SpawnObstacle()
    {
        float cameraRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        float spawnX = cameraRight + offsetFromRight;

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
