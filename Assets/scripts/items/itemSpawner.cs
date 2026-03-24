using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    [Header("Items")]
    public GameObject[] itemPrefabs;

    private void Start()
    {
        TrySpawn();
    }

    void TrySpawn()
    {
        if (itemPrefabs.Length == 0)
        {
            Debug.LogWarning("Inga itemPrefabs");
            return;
        }

        // Välj ett random item
        int index = Random.Range(0, itemPrefabs.Length);
        GameObject itemToSpawn = itemPrefabs[index];

        Instantiate(itemToSpawn, transform.position, Quaternion.identity);
    }
}
