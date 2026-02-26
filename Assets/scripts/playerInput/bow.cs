using UnityEngine;
using UnityEngine.InputSystem;

public class bow : MonoBehaviour
{
    //så den vet om firePoint och arrowPrefab
    public Transform firePoint;
    public GameObject arrowPrefab;

    //pew pew
    public InputActionReference shootAction;

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

    void shoot() 
    { 
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation); 
    }
}