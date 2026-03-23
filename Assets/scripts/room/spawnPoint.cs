using UnityEngine;

public class spawnPoint : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Transform spawn = GameObject.Find(SpawnManager.nextSpawnPoint).transform;

        if (player != null && spawn != null)
        {
            player.transform.position = spawn.position;
        }
    }
}
