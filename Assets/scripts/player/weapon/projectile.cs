using UnityEngine;
using UnityEngine.InputSystem;

public class arrow : MonoBehaviour
{
    [SerializeField] public float speed = 10f;
    private Vector2 moveDirection;
    private int isMelee;

    public void SetIsMelee(int value)
    {
        isMelee = value;
    }

    void Start()
    {
        // 1. Get mouse world position
        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = 0f;

        // 2. Calculate direction
        Vector2 dir = (mouseWorldPos - transform.position).normalized;

        // 3. Rotate arrow ONCE toward mouse
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // 4. Set movement direction
        moveDirection = dir;
    }

    void Update()
    {
        if (isMelee == 1)
            Invoke(nameof(meleeAttackDuration), 0.25f);

        // 5. Move forward
        transform.position += (Vector3)moveDirection * speed * Time.deltaTime;
    }

    void meleeAttackDuration()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return;
        Destroy(gameObject);
    }
}
