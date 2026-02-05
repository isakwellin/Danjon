using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    //public Transform player;
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    private UnityEngine.Vector2 movement;
    private SpriteRenderer sr;
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 direction = player.transform.position - transform.position; //melee_enemy jämfört med player
        rb.linearVelocityX = direction.x;
        direction.Normalize();
        movement = direction;
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
        rb.MovePosition((UnityEngine.Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
