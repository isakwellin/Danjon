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
        // transition saker
        transition.Rebind();
        transition.Update(0f);
        transition.SetTrigger("start");

        yield return new WaitForSeconds(transitionTime);

        // Ladda scenen i bakgrunden
        AsyncOperation load = SceneManager.LoadSceneAsync(levelName);
        load.allowSceneActivation = false;

        // Vänta tills scenen är klar (90%)
        while (load.progress < 0.9f)
        {
            yield return null;
        }

        // starta scenen
        load.allowSceneActivation = true;
    }
}
