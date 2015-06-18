using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimedButton : MonoBehaviour
{
    public Text text;
    private string initialText = "";

    public float time = 5f;

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.interactable = false;

        initialText = text.text;
        text.text = string.Format("{0} ({1})", initialText, (int)time);
    }

    void OnEnable()
    {
        StartCoroutine("Timer");
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            time -= 1;

            text.text = string.Format("{0} ({1})", initialText, (int)time);

            if (time <= 0)
            {
                button.interactable = true;
                text.text = initialText;
                break;
            }
        }
    }
}
