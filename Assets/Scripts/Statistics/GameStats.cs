using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{
    public Text scoreText;
    public Color highScoreTint;
    public Text timeText;

    public GameObject pauseScreen;
    public Text pauseText;

    [HideInInspector]
    public bool isGamePaused = false;
    [HideInInspector]
    public bool isPlayerAlive = true;

    public int score = 0;
    public bool isHighScore = false;
    public float time = 0;

    void Start()
    {
        pauseScreen.SetActive(false);
    }

    void Update()
    {
        if (!isGamePaused)
        {
            scoreText.text = "Score: " + score;

            if (isHighScore)
                scoreText.GetComponent<Gradient>().bottomColor = highScoreTint;

            time += Time.deltaTime;
            timeText.text = "Time: " + Helper.SecondsToTimeString(time);
        }

        if (Input.GetButtonDown("Pause"))
            PauseGame();

        if (isGamePaused && isPlayerAlive)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void AddScore(int amount)
    {
        score += amount;

        if (score > PlayerPrefs.GetInt("highScore"))
            isHighScore = true;
    }

    public void SetPlayerDead()
    {
        pauseScreen.SetActive(true);
        pauseText.text = "You have died...";
        isGamePaused = true;
        isPlayerAlive = false;

        SaveStats();
    }

    void PauseGame()
    {
        if (isPlayerAlive)
        {
            pauseText.text = "Game Paused";
            isGamePaused = !isGamePaused;
            pauseScreen.SetActive(isGamePaused);

            SaveStats();
        }
    }

    void SaveStats()
    {
        if (isHighScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.SetFloat("highScoreTime", time);
        }

        PlayerPrefs.SetFloat("totalTime", PlayerPrefs.GetFloat("totalTime") + time);
    }
}
