using UnityEngine;
using UnityEngine.Networking.PlayerConnection;
using UnityEngine.UIElements;

public class healItem : MonoBehaviour
{
    public int healAmount = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        health hp = other.GetComponent<health>();

        if (hp != null && hp.isPlayer)
        {
            hp.heal(healAmount);
            Destroy(gameObject);
        }
    }
}
