using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatsText : MonoBehaviour
{
    //Stat variables
    private int highScore = 0;
    private float time = 0; //Time in seconds
    private string timeText = ""; //Time in minutes and seconds

    private int totalDeaths = 0;
    private int totalKills = 0;

    private float totalTime = 0;
    private string totalTimeText = "";

    private Text textComponent;
    private string text;

    void Start()
    {
        textComponent = gameObject.GetComponent<Text>();

        if (Input.GetKey(KeyCode.P))
            PlayerPrefs.DeleteAll();
        LoadStats();

        text = string.Format(
            textComponent.text, 
            highScore, 
            timeText, 
            totalDeaths, 
            totalKills,
            totalTimeText
            );

        textComponent.text = text;
    }

    void LoadStats()
    {
        //Load stats from playerprefs, or use default values
        highScore = PlayerPrefs.GetInt("highScore", 0);
        time = PlayerPrefs.GetFloat("highScoreTime", 0);

        totalDeaths = PlayerPrefs.GetInt("totalDeaths", 0);
        totalKills = PlayerPrefs.GetInt("totalKills", 0);

        totalTime = PlayerPrefs.GetFloat("totalTime", 0);

        //Convert time in seconds to minutes and seconds
        timeText = Helper.SecondsToTimeString(time);
        totalTimeText = Helper.SecondsToTimeString(totalTime);
    }
}
