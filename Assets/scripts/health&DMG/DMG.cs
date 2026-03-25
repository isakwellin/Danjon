using UnityEngine;

public class DMG : MonoBehaviour
{
    public int damage = 20;
    public float attackCooldown = 0.5f;
    public bool destroyOnHit = false; // ranged = true, melee = false

    private float nextAttackTime = 0f;

    private void OnCollisionEnter2D(Collision2D collision) // kollar efter träff
    {
        if (collision.collider.CompareTag("enemy")) // för att ignorera enemy
            return;

        dealDamage(collision.gameObject);

        if (destroyOnHit)
            Destroy(gameObject); //förstör gameobject
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("enemy")) // för att ignorera enemy
            return;
        dealDamage(collision.gameObject);
    }

    private void dealDamage(GameObject target) // dmg funktion
    {

        if (Time.time < nextAttackTime) return; // behöver vänta tid innan den kan skada igen

        var health = target.GetComponent<health>();
        if (health != null)
        {
            health.takeDamage(damage);
            nextAttackTime = Time.time + attackCooldown;
        }
    }
}