using UnityEngine;

public class weaponChoice : MonoBehaviour
{
    public GameObject choiceUI; // canvas med 2 knappar

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            choiceUI.SetActive(true); // visar UI
            Time.timeScale = 0f; // pausar spelet
        }
    }
}
