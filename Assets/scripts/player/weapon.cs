using UnityEngine;
using UnityEngine.InputSystem;

public class bow : MonoBehaviour
{
    //så den vet om firePoint och arrowPrefab
    public Transform firePoint;
    public GameObject arrowPrefab;
    public GameObject meleePrefab;

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
        //skjuter
        shootAction.action.Enable(); shootAction.action.performed += OnShoot; 
    }

    void OnDisable() 
    { 
        //slutar skjuta
        shootAction.action.performed -= OnShoot; shootAction.action.Disable(); 
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
