using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Button _startButton;
    [SerializeField] Button _creditButton;
    [SerializeField] Button _exitButton;

    // Start is called before the first frame update
    void Start()
    {
        _startButton.onClick.AddListener(StartGame);
        _creditButton.onClick.AddListener(CreditScene);
        _exitButton.onClick.AddListener(ExitGame);

    }


    private void StartGame()
    {
        GameStateManager.Instance.LoadScene(GameStateManager.Scene.Intro);
    }

    private void CreditScene()
    {
        GameStateManager.Instance.LoadScene(GameStateManager.Scene.GameCredits);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
