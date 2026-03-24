using UnityEngine;

public class DMG : MonoBehaviour
{
    public int damage = 20;
    public float attackCooldown = 0.5f;
    public bool destroyOnHit = false; // ranged = true, melee = false

    private float nextAttackTime = 0f;

    private void OnCollisionEnter2D(Collision2D collision) // kollar efter träff
    {
        dealDamage(collision.gameObject);

        if (destroyOnHit)
            Destroy(gameObject); //förstör gameobject
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        dealDamage(collision.gameObject);
    }

    private void dealDamage(GameObject target)
    {
        if (Time.time < nextAttackTime) return;

        var health = target.GetComponent<health>();
        if (health != null)
        {
            health.takeDamage(damage);
            nextAttackTime = Time.time + attackCooldown;
        }
    }
}