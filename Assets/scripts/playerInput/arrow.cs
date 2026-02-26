using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;
public class arrow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    //hastighet på pilen
    [SerializeField] public float speed = 10f;
    private Vector2 moveDirection;
    
    public void Initialize(Vector2 direction)
    {
        moveDirection = direction;

    }
    void RotateTowardsMouse()
    {

        //kollar var musen är
        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        //gör så pilen kollar ditåt
        Vector2 direction = mouseWorldPos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; transform.rotation = Quaternion.Euler(0, 0, angle);
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        //ignorerar player
        if (collision.CompareTag("Player")) return;

        //förstör pilen
        Destroy(gameObject); 
    }
    void Start()
    {
        //roterar och riktning
        RotateTowardsMouse();
        moveDirection = transform.right;
    }
    void Update()
    {
        transform.position += (Vector3)moveDirection * speed * Time.deltaTime;
    }



}
