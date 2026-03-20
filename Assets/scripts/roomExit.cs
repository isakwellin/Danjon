using UnityEngine;

public class roomExit : MonoBehaviour
{
    [SerializeField] private string nextLevelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<playerMovement>() != null)
        {
            roomChange.instance.nextRoom(nextLevelName);
        }
    }
}
