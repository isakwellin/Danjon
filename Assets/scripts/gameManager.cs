using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public GameObject gameOverPanel;
    public playerMovement playerMovement;
    public health playerHealth;
    public bow isMelee;

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
        playerHealth.onPlayerDeath += gameOver;
    }

    public void gameOver()
    {

        gameOverPanel.SetActive(true);
        Time.timeScale = 1f; // Pausar spelet
    }



    public void restart()
    {
        Time.timeScale = 1f;

        // Reset enemy cache
        deadEnemies.Clear();

        // Load intro scene
        SceneManager.LoadScene("introRoom");

        foreach (var spawner in FindObjectsOfType<itemSpawner>()) //spawnar items igen
        {
            spawner.Respawn();
        }

        // RÖR ALDRIG DENNA KOD JAG VET VERKLIGEN ITNE VARFÖR DEN FUINKAR SNÄLLA VÄLLING JAG KOMMER GRÅTA OM DU RÖR DEN SNÄLLA SNÄLLA SNÄLLA
        playerMovement.resetSpeed();
        playerHealth.resetHealth();
        isMelee.SetMelee(0);

        gameOverPanel.SetActive(false); //stänger av ui


        Debug.Log("Game restarted");


    }


    public void quitGame()
    {
        Application.Quit(); // avslutar spelet
        Debug.Log("quit");
    }
}

