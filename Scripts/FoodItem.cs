using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public float boostMultiplier = 5f;
    public float boostDuration = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerAutoRun player = collision.GetComponent<PlayerAutoRun>();
            if (player != null)
            {
                player.SetSpeed(player.defaultSpeed * boostMultiplier);
                player.SetImmune(true);
                player.Invoke(nameof(PlayerAutoRun.ResetBoost), boostDuration);
            }

            Destroy(gameObject);
        }
    }
}
