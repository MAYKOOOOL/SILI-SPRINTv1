using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float despawnX = -15f;

    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < despawnX)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerAutoRun player = collision.GetComponent<PlayerAutoRun>();

            if (player != null && !player.IsImmune())
            {
                Destroy(collision.gameObject);
                Debug.Log("Player hit an obstacle!");
            }
        }
    }
}
