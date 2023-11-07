using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CreditsScript : MonoBehaviour
{
    [SerializeField] Button _homeButton;

    // Start is called before the first frame update
    void Start()
    {
        Scene currScene = SceneManager.GetActiveScene();

        string sceneName = currScene.name;

        if(sceneName == "GameLoseCredits")
        {
            _homeButton.onClick.AddListener(LoadLoseMenu);
        }
        else if(sceneName == "GameWinCredits")
        {
            _homeButton.onClick.AddListener(LoadWinMenu);
        }
        else if(sceneName == "GameCredits")
        {
            _homeButton.onClick.AddListener(LoadMenu);
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadMenu()
    {
        GameStateManager.Instance.LoadScene(GameStateManager.Scene.MainMenu);
    }

    private void LoadWinMenu()
    {
        GameStateManager.Instance.LoadScene(GameStateManager.Scene.GameWin);
    }

    private void LoadLoseMenu()
    {
        GameStateManager.Instance.LoadScene(GameStateManager.Scene.GameOver);
    }

}
