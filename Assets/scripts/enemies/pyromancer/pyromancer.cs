using UnityEngine;

public class pyromancer : MonoBehaviour
{

    public float moveSpeed;
    GameObject player;

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

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }


    [SerializeField] private string enemyID;//enemyID


    private void Awake()
    {
        if (string.IsNullOrEmpty(enemyID))
        {
            enemyID = System.Guid.NewGuid().ToString(); //ger nytt ID
        }

        if (gameManager.instance.deadEnemies.Contains(enemyID)) // kollar bland döda fiender
        {
            gameObject.SetActive(false);
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        // Endast generera ID om objektet ligger i scenen, inte i en prefab
        if (string.IsNullOrEmpty(enemyID) && gameObject.scene.IsValid())
        {
            enemyID = System.Guid.NewGuid().ToString();
            UnityEditor.EditorUtility.SetDirty(this);
        }
    }
#endif

    public string ID => enemyID;
    public void Die()
    {
        gameManager.instance.deadEnemies.Add(enemyID); //lägger ID i "död" fil ställe
        gameObject.SetActive(false); //dödar fienden
    }



    // Update is called once per frame
    void Update()
    {
        Vector3 difference = player.transform.position - weapon.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        weapon.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if(Vector2.Distance(transform.position, player.transform.position) < followPlayerRange && Vector2.Distance(transform.position, player.transform.position) > attackRange)
        {
            inRange = true;
        } 
        else
        {
            inRange = false;
        }

        if(Vector2.Distance(transform.position, player.transform.position) <= attackRange)
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

        if(Vector2.Distance(transform.position, player.transform.position) <= rangeToBack)
        {
            Vector2 direction = transform.position - player.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + direction, moveSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        if (inRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
    }
}
