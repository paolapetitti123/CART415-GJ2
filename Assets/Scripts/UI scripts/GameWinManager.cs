using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWinManager : MonoBehaviour
{
    [SerializeField] Button _replayButton;
    [SerializeField] Button _gameCreditsButton;
    [SerializeField] Button _exitButton;
    // Start is called before the first frame update
    void Start()
    {
        Scene currScene = SceneManager.GetActiveScene();

        string sceneName = currScene.name;

        if(sceneName == "GameOver")
        {
            _gameCreditsButton.onClick.AddListener(GameLoseCredits);
        }
        else if(sceneName == "GameWin")
        {
            _gameCreditsButton.onClick.AddListener(GameWinCredits);
        }


        _replayButton.onClick.AddListener(replayGame);

        _exitButton.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void replayGame()
    {
        GameStateManager.Instance.LoadScene(GameStateManager.Scene.Intro);
    }

    private void GameWinCredits()
    {
        GameStateManager.Instance.LoadScene(GameStateManager.Scene.GameWinCredits);
    }

    private void GameLoseCredits()
    {
        GameStateManager.Instance.LoadScene(GameStateManager.Scene.GameLoseCredits);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
