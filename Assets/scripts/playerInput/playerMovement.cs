using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
//using System.Runtime.Remoting.Contexts;


public class playerMovement : MonoBehaviour
{

    //Initialiserar gubbens kropp och hastigheten
    [SerializeField] Rigidbody2D body;
    [SerializeField] float movementSpeed;

    private Animator animator;
    private Vector2 _moveDirection;
    private SpriteRenderer spriteRenderer;

    //X, Y
    private float horizontal;
    private float vertical;

    //Gör så att gubben rör sig
    private void FixedUpdate()
    {
        horizontal = _moveDirection.x;
        vertical = _moveDirection.y;
        body.linearVelocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);

        animator.SetFloat("inputX",horizontal);
        animator.SetFloat("inputY",vertical);

        if (horizontal < -0.01f)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontal > 0.01f)
        {
            spriteRenderer.flipX = true;
        }


        if (_moveDirection.sqrMagnitude > 0.01f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    //Läser av inputs
    public InputActionReference move;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
    }
}
