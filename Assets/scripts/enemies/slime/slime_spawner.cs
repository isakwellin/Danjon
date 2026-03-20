using System.Collections;
using Unity;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
	[SerializeField]
	private GameObject _enemyPrefab;
	
	void Start()
	{
		StartCoroutine(spawn_routine());
	}

	IEnumerator spawn_routine()
	{
		while (true)
		{
			float RNG =Random.Range(0f,0f);
            Vector3 launch = new Vector3(RNG,0,8);
            Instantiate(_enemyPrefab, launch,Quaternion.Euler(0,0,0));
			yield return new WaitForSeconds(5);
		}
	}
}
