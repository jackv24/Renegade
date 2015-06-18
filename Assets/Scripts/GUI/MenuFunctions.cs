using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuFunctions : MonoBehaviour
{
    //Stores the last opened panel
    private GameObject lastPanelOpened;

    //Opens the panel, and closes the last opened panel
    public void TogglePanel(GameObject panel)
    {
        //If there was already a panel open, close it
        if (lastPanelOpened != panel && lastPanelOpened)
            lastPanelOpened.SetActive(false);

        panel.SetActive(!panel.activeInHierarchy);
        lastPanelOpened = panel;
    }

    //Loads the scene with index
    public void LoadScene(int index)
    {
        Application.LoadLevel(index);
    }

    //Reloads the current scene
    public void ReloadScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    //Closes the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
