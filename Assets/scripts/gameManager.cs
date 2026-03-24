using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    public HashSet<string> deadEnemies = new HashSet<string>(); //hash för enemies


    //funktion för att kolla om fiender redan dött eller inte så de inte respawnear
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene("introRoom");
        }
        else
        { 
            Destroy(gameObject);
        }
    }
}
