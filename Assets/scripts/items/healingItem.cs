using UnityEngine;

public class healingItem : MonoBehaviour
{
    public GameObject healingItemPrefab;
    public float dropChance = 0.3f;

    private health enemyHealth;

    private void Awake()
    {
        enemyHealth = GetComponent<health>();
        enemyHealth.onEnemyDeath += handleDeath;
    }

    void handleDeath()
    {
        if (Random.value <= dropChance)
        {
            Instantiate(healingItemPrefab, transform.position,Quaternion.identity);
        }
    }
}
