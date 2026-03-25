using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    [Header("Items")]
    public GameObject[] itemPrefabs; //lista med items

    private GameObject currentItem;

    private void Start()
    {
        TrySpawn();
    }

    void TrySpawn()
    {
        if (itemPrefabs.Length == 0) // debug
        {
            Debug.LogWarning("Inga itemPrefabs");
            return;
        }

        int index = Random.Range(0, itemPrefabs.Length); //väljer random item
        GameObject itemToSpawn = itemPrefabs[index];

        currentItem = Instantiate(itemToSpawn, transform.position, Quaternion.identity); //spawnar itemet
    }

    public void Respawn() //respawn funktion för att kunna restarta spelet
    {
        if (currentItem != null)
            Destroy(currentItem);

        TrySpawn();
    }
}