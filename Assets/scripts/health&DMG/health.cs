using UnityEngine;
using UnityEngine.Events;

public class health : MonoBehaviour
{


    //maxhp och currenthp
    public float maxHealth = 100;
    public float currentHealth { get; private set; }

    public bool isPlayer = false; // för att bestämma vem som är spelare

    //events
    [Header("Events")]
    public UnityEvent onDamaged;
    public UnityEvent onHealed;


    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void increaseHealth(float multiplier)
    {
        maxHealth *= multiplier; // maxHP multiplier för items

        currentHealth = maxHealth;
        onHealed?.Invoke();

    }

    //Metod för att ta skada och kolla om spelarens hp är 0 (då är spelet över)
    public void takeDamage(int damage)
    {

        // tar dmg
        currentHealth -= damage;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (isPlayer)
        { //blinka lilla stjärna
            GetComponent<playerMovement>().StartCoroutine("damageBlink");
        }

        // dmg event
        onDamaged?.Invoke();

        //0hp=död
        if (currentHealth <= 0)
        {
            Debug.Log("Dead");

            Enemy enemy = GetComponent<Enemy>();
            pyromancer enemy2 = GetComponent<pyromancer>();
            if (enemy!= null)
            {
                enemy.Die();   // död i enemy saken
            }
            if (enemy2 != null)
            {
                enemy2.Die();
            }
            else
            {
                Destroy(gameObject); //player
            }
        }

    }

    public void heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        onHealed?.Invoke();
    }
}

