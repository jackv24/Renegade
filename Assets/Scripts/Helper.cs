using UnityEngine;
using System.Collections;

public static class Helper
{
    public static string SecondsToTimeString(float time)
    {
        string timeText = "";

        int minutes = (int)Mathf.Floor(time / 60);
        float seconds = Mathf.RoundToInt(time % 60);

        timeText = minutes.ToString("00") + ":" + seconds.ToString("00");

        return timeText;
    }
}
