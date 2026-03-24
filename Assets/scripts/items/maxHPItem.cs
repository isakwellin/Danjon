using UnityEngine;

public class maxHPItem : MonoBehaviour
{
    [SerializeField] private float HPMultiplier = 1.5f; // ger 50% maxHP buff



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            health player = collision.GetComponent<health>(); // kollar efter kollisioner

            if (player != null)
            {
                player.increaseHealth(HPMultiplier); // ger buff
            }

            Destroy(gameObject); // förstör item
        }
    }
}