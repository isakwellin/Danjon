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
        // mus position
        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        // ta reda på riktningen
        Vector2 dir = (mouseWorldPos - transform.position).normalized;

        // rotera dit
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // skjut
        moveDirection = dir;
    }

    void Update()
    {
        //tid innan melee attack försvinner
        if (isMelee == 1)
            Invoke(nameof(meleeAttackDuration), 0.25f);
        
        //rör vapnet
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
