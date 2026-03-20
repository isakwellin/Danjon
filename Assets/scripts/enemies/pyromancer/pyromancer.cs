using UnityEngine;

public class pyromancer : MonoBehaviour
{

    public float moveSpeed;
    public Transform player;

    //Variabeln som bestämmer var projectiles ska spawna
    public Transform shotPoint;

    public Transform weapon;

    public GameObject enemyProjectile;

    public float followPlayerRange;
    private bool inRange;
    public float attackRange;

    //Variabeln som bestämmer hur nära spelaren får vara innan fienden backar undan
    public float rangeToBack;

    public float startTimeBetweenShots;
    private float timeBetweenShots;

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = player.position - weapon.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        weapon.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if(Vector2.Distance(transform.position, player.position) < followPlayerRange && Vector2.Distance(transform.position, player.position) > attackRange)
        {
            inRange = true;
        } 
        else
        {
            inRange = false;
        }

        if(Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            if (timeBetweenShots <= 0)
            {
                Instantiate(enemyProjectile, shotPoint.position, shotPoint.transform.rotation);
                timeBetweenShots = startTimeBetweenShots;
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }

        if(Vector2.Distance(transform.position, player.position) <= rangeToBack)
        {
            Vector2 direction = transform.position - player.position;
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + direction, moveSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        if (inRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }
}
