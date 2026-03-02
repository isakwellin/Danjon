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

    //Kollar om melee
    private bool isMelee = true;

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
        if (isMelee)
        {
            Instantiate(meleePrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        }
    }
}