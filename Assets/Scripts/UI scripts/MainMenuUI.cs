using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Button _startButton;

    // Start is called before the first frame update
    void Start()
    {
        _startButton.onClick.AddListener(startGame);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void startGame()
    {
        GameStateManager.Instance.LoadScene(GameStateManager.Scene.Tutorial);
    }
}
