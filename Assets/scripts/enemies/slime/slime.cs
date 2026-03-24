using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    //moveSpeed
    [SerializeField] public float moveSpeed = 1f;

    //rigidbody med mera
    private Rigidbody2D rb;
    private UnityEngine.Vector2 movement;
    private SpriteRenderer sr;
    GameObject player;

    [SerializeField] private string enemyID;//enemyID


    private void Awake()
    {
        Debug.Log("Enemy spawned with ID: " + enemyID);

        if (string.IsNullOrEmpty(enemyID))
        {
            enemyID = System.Guid.NewGuid().ToString();
            Debug.Log("Generated new ID: " + enemyID);
        }

        if (gameManager.instance.deadEnemies.Contains(enemyID))
        {
            Debug.Log("Enemy already dead: " + enemyID);
            gameObject.SetActive(false);
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        // Endast generera ID om objektet ligger i scenen, inte i en prefab
        if (string.IsNullOrEmpty(enemyID) && gameObject.scene.IsValid())
        {
            enemyID = System.Guid.NewGuid().ToString();
            UnityEditor.EditorUtility.SetDirty(this);
        }
    }
#endif

    public string ID => enemyID;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //hittar "Player" och GetComponent saker
        player = GameObject.FindWithTag("Player");
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
    }


    public void Die()
    {
        gameManager.instance.deadEnemies.Add(enemyID); //lägger ID i "död" fil ställe
        gameObject.SetActive(false); //dödar fienden
    }



    // Update is called once per frame
    void Update()
    {
        //gör så den vet åt vilket håll "Player" är åt
        UnityEngine.Vector3 direction = player.transform.position - transform.position;

        //gå saker
        rb.linearVelocityX = direction.x;
        direction.Normalize();
        movement = direction;

        //gör så den kollar åt rätt håll
        if (rb.linearVelocity.x > 0.01f)
            sr.flipX = false;
        else if (rb.linearVelocity.x < -0.01f)
            sr.flipX = true;

    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(UnityEngine.Vector2 direction)
    {
        //själva gåendet
        rb.MovePosition((UnityEngine.Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void flashStart() //blinkar rött vid skada
    {
        sr.color = Color.red;
        Invoke("flashStop", 0.15f);
    }

    void flashStop()
    {
        sr.color = Color.green;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        flashStart();

    }
}