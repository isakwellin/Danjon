using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{

    //Spriterenderer för att ändra gubbens färg när han blir skadad
    public SpriteRenderer spriteRenderer;

    //Initierar hp variabler och sätter max hp till 100
    public int maxHealth = 100;
    public int currentHealth;

    //Hur lång tid det måste gå innan spelaren kan ta skada igen
    public float iFrameDuration = 1f;
    public bool isInvincible;

    //Slider för health baren
    public Slider slider;

    //Metod för att ta skada och kolla om spelarens hp är 0 (då är spelet över)
    void takeDamage(int damage)
    {
        //Tar skada
        currentHealth -= damage;

        //Ändrar health slidern att passa current hp
        slider.value = currentHealth;


        //Om health är 0, alltså man är död
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

    //När spelaren kolliderar med slime eller eldboll
    private void OnCollisionStay2D(Collision2D collision)
    {
        //När spelaren blir träffad av slime förloras 20 hp
        if (collision.gameObject.CompareTag("enemy"))
        {
            if (isInvincible) return;

            //Ta 20 skada
            takeDamage(20);

            StartCoroutine(InvincibilityFrames());
        }
    }

    //När spelaren kolliderar med en fireball

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fireball"))
        {
            if (isInvincible) return;

            //Ta 20 skada
            takeDamage(10);

            StartCoroutine(InvincibilityFrames());
        }
    }

    //Metod för att spelaren inte ska kunna ta skada många gånger snabbt
    private IEnumerator InvincibilityFrames()
    {
        isInvincible = true;

        float elapsed = 0;
        
        //Om tiden som har gått är under tiden som gubben ska vara oskadbar
        while(elapsed < iFrameDuration)
        {
            //Få spelaren att blinka till för att markera att han inte kan ta skada
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.b, spriteRenderer.color.b, 0.3f);
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.b, spriteRenderer.color.b, 1);
            yield return new WaitForSeconds(0.1f);

            elapsed += 0.2f;
        }
            
        //Sätt tillbaka gubben till sitt normala tillstånd (inget blinkande)
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.b, spriteRenderer.color.b, 1);

        //Är inte oskadbar längre
        isInvincible = false;
    }   
}
