using UnityEngine;

public class victory : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = Vector2.zero; //teleport till 0,0 så det ser ut som han gått igenom dörren
            gameManager.instance.victoryPanel();
        }
    }
}
