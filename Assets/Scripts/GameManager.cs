using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int lives { get; private set; }
   
    [SerializeField] private Text livesText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject shipPrefab;
    private GameObject Life1, Life2, Life3;

    public ScoreManager Scoremanager;
    public GameObject SpawnHomingL;
    public GameObject SpawnHomingR;
    public GameObject SpawnCircL;
    public GameObject SpawnCircR;
    public GameObject SpawnDrop;

    // Start is called before the first frame update
    private void Awake() 
    {
        Scoremanager = Scoremanager.GetComponent<ScoreManager>();

        //Finds the UI elements dedicated to displaying lives
        Life1 = GameObject.FindGameObjectWithTag("Life 1");
        Life2 = GameObject.FindGameObjectWithTag("Life 2");
        Life3 = GameObject.FindGameObjectWithTag("Life 3");
    }
    void Start()
    {

        if (instance == null) instance = this;   
        lives = 3; //Sets player's lives to 3

    }


    public void UpdateLives(int i) //Depending on how many lives the player has,it changes the number of lives displayed on the UI accordingly
    {
        if (i == 1) //If the player is Hit by an enemy
        {
            // Player is alive
            if (lives == 3)
            {
                Life1.SetActive(false);
            }
            else if (lives == 2)
            {
                Life2.SetActive(false);
            }
            else if (lives == 1)
            {
                Life3.SetActive(false);
                
                // Player died
                gameOverPanel.SetActive(true);
                Invoke("StartAgain", 1.0f);
                Time.timeScale = 0.3f;
            }
            else if (lives <= 0)
            {

            }
            lives--;
        }
        else if (i == 2) //If the player picks up an extra life
        {
            // Player is alive
            if (lives == 2)
            {
                Life1.SetActive(true);
            }
            else if (lives == 1)
            {
                Life2.SetActive(true);
            }
            lives += 2;
        }

    }



    public void StartAgain() //Restarts the game on player death
    {
        gameOverPanel.SetActive(false);
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1f;
    }




    void Update() //Checks the player's current score and spawns new enemy types or increases their spawnrate accordingly
    {
        if (Scoremanager.score >= 700)
        {
            SpawnHomingR.SetActive(true);
        }
        if (Scoremanager.score >= 2200)
        {
            SpawnDrop.SetActive(true);
        }
        if (Scoremanager.score >= 3300)
        {
            SpawnCircL.SetActive(true);
        }
        if (Scoremanager.score >= 4000)
        {
            SpawnCircR.SetActive(true);
        }
        if (Scoremanager.score >=5000)
        {
          SpawnHomingR.GetComponent<Spawner>().interval = 2.7f;
        }
        if (Scoremanager.score >= 5500)
        {
            SpawnHomingL.GetComponent<Spawner>().interval = 2.3f;
        }
        if (Scoremanager.score >= 6500)
        {
            SpawnDrop.GetComponent<Spawner>().interval = 4f;
        }
        if (Scoremanager.score >= 7500)
        {
            SpawnCircL.GetComponent<Spawner>().interval = 4.5f;
        }
        if (Scoremanager.score >= 8000)
        {
            SpawnHomingR.GetComponent<Spawner>().interval = 4.2f;
        }
        if (Scoremanager.score >= 10000)
        {
            SpawnHomingR.GetComponent<Spawner>().interval = 2f;
        }
        if (Scoremanager.score >= 12000)
        {
            SpawnHomingL.GetComponent<Spawner>().interval = 2f;
        }

    }


}

