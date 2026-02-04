using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 1f;
    private Rigidbody2D body;
    private UnityEngine.Vector2 movement;
    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 direction = player.position - transform.position; //melee_enemy jämfört med player
        body.linearVelocityX = direction.x;
        direction.Normalize();
        movement = direction;
        if (body.linearVelocity.x > 0.01f)
            sr.flipX = false;
        else if (body.linearVelocity.x < -0.01f)
            sr.flipX = true;

    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(UnityEngine.Vector2 direction)
    {
        body.MovePosition((UnityEngine.Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
