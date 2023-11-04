using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWinManager : MonoBehaviour
{
    [SerializeField] Button _replayButton;
    [SerializeField] Button _mainMenuButton;
    [SerializeField] Button _exitButton;
    // Start is called before the first frame update
    void Start()
    {
        _replayButton.onClick.AddListener(replayGame);
        _mainMenuButton.onClick.AddListener(mainMenu);
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

    private void mainMenu()
    {
        GameStateManager.Instance.LoadScene(GameStateManager.Scene.MainMenu);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
