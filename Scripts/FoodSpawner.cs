using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public float spawnInterval = 7f;
    public float spawnY = -4.75f;
    public float offsetFromRight = 2f;
    public Camera mainCamera;
    public Transform player;

    void Start()
    {
        InvokeRepeating(nameof(SpawnFood), 1f, spawnInterval);
    }

    void SpawnFood()
    {
        float cameraRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        float spawnX = cameraRight + offsetFromRight;
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);
        Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
    }
}