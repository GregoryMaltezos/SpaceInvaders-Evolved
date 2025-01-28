using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public Text highscoreText;

    public int score = 0;
    int highScore = 0;


    private void Awake()
    {
        instance = this;
    }

    
    void Start()
    {

        /// <summary>
        /// Reads PlayerPrefs in order to display what the player's current score and highscore are
        /// </summary>

        highScore = PlayerPrefs.GetInt("HighScore"); 
        scoreText.text ="Score: " + score.ToString(); 
        highscoreText.text = "Highscore: " + highScore.ToString();
    }

    public void AddPoint()
    {
        /// <summary>
        /// After enemy is killed, saves and updates Score and Highscore
        /// </summary>
        score += Enemy.points;
        scoreText.text = "Score: " +  score.ToString();
        if(highScore < score)
        PlayerPrefs.SetInt("HighScore", score);
    }

}
