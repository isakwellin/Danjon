using UnityEngine;

public class DMGRanged : MonoBehaviour
{
    // floats
    public float damage = 20;
    public float attackCooldown = 0.5f;
    private float nextAttackTime = 0f;

    void OnTriggerEnter2D(Collider2D collision)
    {

        // Only damage enemies (kan nog ta bort genom collision matrix hmmmmmmmmmmmmmmmmmm)
        if (!collision.CompareTag("enemy"))
            return;

        if (Time.time < nextAttackTime) return;

        var health = collision.gameObject.GetComponent<health>();
        if (health != null)
        {
            health.takeDamage((int)damage); // göra dmg
            nextAttackTime = Time.time + attackCooldown; //göra dmg och få cooldown
        }
    }
}
