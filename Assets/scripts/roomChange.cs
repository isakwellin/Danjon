using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class roomChange : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public static roomChange instance;

    private void Awake()
    {
        instance = this;
    }

    public void nextRoom(string levelName)
    {
        StartCoroutine(loadRoom(levelName));
    }

    IEnumerator loadRoom(string levelName)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);

        // Wait one frame so the scene loads
        yield return null;

        GameObject player = GameObject.FindWithTag("Player");
        Transform spawn = GameObject.Find("SpawnPoint").transform;

        player.transform.position = spawn.position;
    }

}
