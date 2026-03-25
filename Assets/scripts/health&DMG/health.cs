using UnityEngine;
using UnityEngine.Events;
using System;

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
    public event Action onPlayerDeath;
    public event Action onEnemyDeath;


    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void increaseHealth(float multiplier) //maxHP item funktion
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
        if (currentHealth <= 0) //död funktion
        {
            Enemy enemy = GetComponent<Enemy>();
            pyromancer enemy2 = GetComponent<pyromancer>();
            if (enemy!= null)
            {
                enemy.Die();   // död i enemy saken
                Debug.Log("Dead slime");
                onEnemyDeath?.Invoke();
            }
            else if (enemy2 != null)
            {
                enemy2.Die(); //pyromancer enemy
                Debug.Log("Dead pyro");
                onEnemyDeath?.Invoke();
            }
            else
            {
                Debug.Log("Dead player");
                transform.position = Vector2.zero; //teleport till 0,0 så det ser ut som han dött utan att dö
                onPlayerDeath?.Invoke();
            }
        }

    }


    public void heal(int amount) // healing för om det skulle vara med
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        onHealed?.Invoke();
    }
}

