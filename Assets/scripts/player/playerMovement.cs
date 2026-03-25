using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
//using System.Runtime.Remoting.Contexts;
//runtime saken är onödig varför fanns den äns????????


public class playerMovement : MonoBehaviour
{

    private static playerMovement instance;

    //Initialiserar gubbens kropp och hastigheten
    [SerializeField] Rigidbody2D body;
    [SerializeField] float movementSpeed;


    //spriterenderer och animator för animationer
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private Vector2 _moveDirection;


    //X, Y
    private float horizontal;
    private float vertical;


    public void resetSpeed() // reset speed
    {
        movementSpeed = 12f;
    }
    public void increaseSpeed(float multiplier)
    {
        movementSpeed *= multiplier; // speed multiplier för items
    }




    //Gör så att gubben rör sig
    private void FixedUpdate()
    {

        horizontal = _moveDirection.x;
        vertical = _moveDirection.y;
        body.linearVelocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);


        //floats för att kolla vilken animation som ska köras
        animator.SetFloat("inputX",horizontal);
        animator.SetFloat("inputY",vertical);


        //flippar gubben så han går åt rätt håll för haglund gav bara sideways
        if (horizontal < -0.01f)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontal > 0.01f)
        {
            spriteRenderer.flipX = true;
        }


        //kollar om han går eller ej för idle animations skull
        if (_moveDirection.sqrMagnitude > 0.01f)
        {
            animator.SetBool("isWalking", true);
            animator.SetFloat("inputLastX", horizontal);
            animator.SetFloat("inputLastY", vertical);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }


    private IEnumerator damageBlink()
    {

        float elapsed = 0;

        //Om tiden som har gått är under tiden som gubben ska vara oskadbar
        while (elapsed < 0.5)
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
    }

    //Läser av inputs
    public InputActionReference move;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //GetComponent baby
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        move.action.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
    }
}
