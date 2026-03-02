using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{

    //initierar hp variabler och sätter max hp till 100
    public int maxHealth = 100;
    public int currentHealth;

    //Slider för health baren
    public Slider slider;

    //Metod för att ta skada och kolla om spelarens hp är 0 (då är spelet över)
    void takeDamage(int damage)
    {
        currentHealth -= damage;
        slider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Debug.Log("Game over!");
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //När spelaren kolliderar med fienden förloras 10 hp
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            takeDamage(10);
        }
    }
}
