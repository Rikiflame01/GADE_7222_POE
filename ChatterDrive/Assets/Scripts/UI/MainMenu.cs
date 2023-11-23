using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScreenType
{
    Start,
    SceneSelector,
    Credits
}

public class MainMenu : MonoBehaviour
{
    [Header("Screens")]
    public GameObject sceneSelector;
    public GameObject startScreen;
    public GameObject creditsScreen;

    public void ShowScreen(int screenNum)
    {
        switch (screenNum)
        { 
            case 1:
                startScreen.SetActive(true);
                sceneSelector.SetActive(false);
                creditsScreen.SetActive(false);
            break;
            case 2:
                startScreen.SetActive(false);
                sceneSelector.SetActive(true);
                creditsScreen.SetActive(false);
            break;
            case 3:
                startScreen.SetActive(false);
                sceneSelector.SetActive(false);
                creditsScreen.SetActive(true);
            break;
        }

        SFXManager.Instance.PlaySound("click1");
    }
}
