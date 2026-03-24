using UnityEngine;

public class DMGRanged : MonoBehaviour
{
    public float damage = 20;
    public float attackCooldown = 0.5f;


    private float nextAttackTime = 0f;

    void OnTriggerEnter2D(Collider2D collision)
    {

        // Only damage enemies
        if (!collision.CompareTag("enemy"))
            return;

        if (Time.time < nextAttackTime) return;

        var health = collision.gameObject.GetComponent<health>();
        if (health != null)
        {
            health.takeDamage((int)damage);
            nextAttackTime = Time.time + attackCooldown;
        }
    }
}
