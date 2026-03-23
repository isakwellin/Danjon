using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class roomChange : MonoBehaviour
{
    //differse public
    public Animator transition;
    public float transitionTime = 1f;
    public static roomChange instance;

    private void Awake()
    {
        instance = this;
    }

    public void nextRoom(string levelName)
    {
        StartCoroutine(loadRoom(levelName)); //startar ändringen
    }

    IEnumerator loadRoom(string levelName)
    {
        transition.Rebind();
        transition.Update(0f);
        transition.SetTrigger("start");
        //startar animation
        yield return new WaitForSeconds(transitionTime); //väntar en strund

        SceneManager.LoadScene(levelName);

        yield return null;
    }

}