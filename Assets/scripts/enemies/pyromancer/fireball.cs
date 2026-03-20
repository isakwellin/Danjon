using Unity.VisualScripting;
using UnityEngine;

public class fireball : MonoBehaviour
{

    public float fireballSpeed;
    public float lifeTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * fireballSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            Destroy(gameObject);
        }
    }

    void destroyProjectile()
    {
        Destroy(gameObject);
    }

}
