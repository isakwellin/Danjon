using UnityEngine;

public class roomExit : MonoBehaviour
{
    [SerializeField] private string nextLevelName;
    [SerializeField] private string spawnPointName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<playerMovement>() != null)
        {
            SpawnManager.nextSpawnPoint = spawnPointName;

            roomChange.instance.nextRoom(nextLevelName); //byter scene till nästa rum

        }
    }
}
