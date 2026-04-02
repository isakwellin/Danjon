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
    public GameObject victory;

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
        playerHealth.onPlayerDeath += gameOver; // om gameOver
    }


    public void victoryPanel()
    {
        victory.SetActive(true);
    }


    public void gameOver()
    {

        gameOverPanel.SetActive(true);
        Time.timeScale = 1f; // Pausar INTE spelet, pausade förut spelet men skapade buggar när den pausades så ändrade på det
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

        victory.SetActive(false);
        gameOverPanel.SetActive(false); //stänger av ui


        Debug.Log("Game restarted");


    }


    public void quitGame()
    {
        Application.Quit(); // avslutar spelet
        Debug.Log("quit");
    }
}

