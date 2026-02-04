using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;


public class playerMovement : MonoBehaviour
{

    //Initialiserar gubbens kropp och hastigheten
    [SerializeField] Rigidbody2D body;
    [SerializeField] float movementSpeed;

    private Vector2 _moveDirection;

    //X, Y
    private float horizontal;
    private float vertical;

    //Gör så att gubben rör sig
    private void FixedUpdate()
    {
        horizontal = _moveDirection.x;
        vertical = _moveDirection.y;
        body.linearVelocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);
    }

    //Läser av inputs
    public InputActionReference move;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
    }
}
