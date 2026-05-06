using UnityEngine;
using UnityEngine.InputSystem;

public class bow : MonoBehaviour
{
    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //så den vet om firePoint och arrowPrefab
    public Transform firePoint;
    public GameObject arrowPrefab;
    public GameObject meleePrefab;

    //animator
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    //pew pew
    public InputActionReference shootAction;

    [SerializeField] private int isMelee = 0;

    //Kollar om melee
    public void SetMelee(int value) //får isMelee
    {
        isMelee = value;
    }


    void OnEnable()
    {
        shootAction.action.started -= OnShoot;
        shootAction.action.performed -= OnShoot;

        shootAction.action.performed += OnShoot;
        shootAction.action.Enable();
    }

    void OnDisable()
    {
        shootAction.action.started -= OnShoot;
        shootAction.action.performed -= OnShoot;

        shootAction.action.Disable();
    }


    private void OnShoot(InputAction.CallbackContext ctx) 
    { 
        //skjuter på riktigt
        shoot(); 
    }

    //Kollar om melee eller ranged
    void shoot()
    {

        if (isMelee == 1)
    {

        //melee animationer och kollar riktningar
        Debug.Log("0");
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorldPos.z = 0;

        Vector2 rawDir = mouseWorldPos - transform.position;


        Vector2 dir = rawDir.normalized;

        int attackDirectionMelee;
        Debug.Log("1");
        // Bestäm riktning (0=Up, 1=Right, 2=Down, 3=Left)

        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
             attackDirectionMelee = dir.x > 0 ? 1 : 3;
        }
        else
        {
             attackDirectionMelee = dir.y > 0 ? 0 : 2;
        }
        Debug.Log("2");
        spriteRenderer.flipX = (attackDirectionMelee == 1);

        animator.SetInteger("meleeDirection", attackDirectionMelee);
        animator.SetTrigger("melee");
        Debug.Log("3");
        GameObject melee = Instantiate(meleePrefab, firePoint.position, firePoint.rotation);
        melee.GetComponent<arrow>().SetIsMelee(1);
        }
    else if (isMelee == 2)
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        arrow.GetComponent<arrow>().SetIsMelee(2);
    }
    }


}
