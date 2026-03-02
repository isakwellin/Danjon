using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    //moveSpeed
    [SerializeField] public float moveSpeed = 1f;

    //rigidbody med mera
    private Rigidbody2D rb;
    private UnityEngine.Vector2 movement;
    private SpriteRenderer sr;
    GameObject player;

    //HP
    private int maxHealth = 50;
    private int currentHealth;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //hittar "Player" och GetComponent saker
        player = GameObject.FindWithTag("Player");
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;

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

    void flashStart()
    {
        sr.color = Color.red;
        Invoke("flashStop", 0.15f);
    }

    void flashStop()
    {
        sr.color = Color.green;
    }


    //När fienden kolliderar med en attack förloras 10 hp, alltså behövs det 5 träffar för att döda den
    private void OnTriggerEnter2D(Collider2D collision)
    {
        flashStart();

        if (collision.CompareTag("arrow"))
        {
            currentHealth -= 10;
        } else 
        { 
            currentHealth -= 25;
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Destroy(this);
        }
    }
}
