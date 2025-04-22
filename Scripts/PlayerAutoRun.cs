using UnityEngine;

public class PlayerAutoRun : MonoBehaviour
{
    public float defaultSpeed = 10f;
    public float speedIncreaseDistance = 150f; // distance interval
    public float speedIncrement = 2f; // how much speed to add per milestone

    private float currentSpeed;
    private bool isImmune = false;
    private float distanceTraveled = 0f;
    private float lastPositionX;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = defaultSpeed;
        lastPositionX = transform.position.x;
    }

    private void Update()
    {
        // Calculate distance traveled since last frame
        float deltaDistance = transform.position.x - lastPositionX;
        distanceTraveled += deltaDistance;
        lastPositionX = transform.position.x;

        // Increase speed every 150 distance
        if (distanceTraveled >= speedIncreaseDistance)
        {
            currentSpeed += speedIncrement;
            distanceTraveled = 0f;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void SetImmune(bool immune)
    {
        isImmune = immune;
    }

    public bool IsImmune()
    {
        return isImmune;
    }

    public void ResetBoost()
    {
        currentSpeed = defaultSpeed;
        isImmune = false;
        distanceTraveled = 0f;
        lastPositionX = transform.position.x;
    }
}
