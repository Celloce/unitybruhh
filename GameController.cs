using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public PanelBarController panelBar;
    public BackgroundController backgroundController;

    void Start()
    {
        panelBar.PlayScene(currentScene);
        backgroundController.SetImage(currentScene.background);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (panelBar.IsCompleted())
            {
                if (panelBar.IsLastSentence())
                {
                    currentScene = currentScene.nextScene;
                    panelBar.PlayScene(currentScene);
                    backgroundController.SwitchImage(currentScene.background);
                }
                else
                {
                    panelBar.PlayNextSentence();
                }
            }
        }
    }
}
