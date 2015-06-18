using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ScrollTextFitter : MonoBehaviour
{
    public RectTransform scrollMask;
    public Scrollbar scrollBar;

    private RectTransform rectTrans;
    private Text text;

    private bool refreshed = false;

    void Awake()
    {
        if (scrollBar)
            scrollBar.enabled = false;
    }

    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (scrollMask && text)
            ScaleTextRect();

        //Makes sure the scrollbar is updated
        if (!refreshed)
        {
            if (scrollBar)
                scrollBar.enabled = true;
            
            refreshed = true;
        }
    }

    void ScaleTextRect()
    {
        if (text.preferredHeight > scrollMask.rect.height)
            rectTrans.sizeDelta = new Vector2(scrollMask.rect.width, text.preferredHeight);
        else
            rectTrans.sizeDelta = new Vector2(scrollMask.rect.width, scrollMask.rect.height);
    }
}
