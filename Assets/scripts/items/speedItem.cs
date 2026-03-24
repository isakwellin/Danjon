using UnityEngine;

public class speedItem : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 1.5f; // ger 50% speed buff


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerMovement player = collision.GetComponent<playerMovement>(); // kollar efter kollisioner

            if (player != null)
            {
                player.increaseSpeed(speedMultiplier); // ger buff
            }

            Destroy(gameObject); // förstör item
        }
    }
}
