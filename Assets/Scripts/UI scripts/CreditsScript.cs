using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsScript : MonoBehaviour
{
    [SerializeField] Button _homeButton;

    // Start is called before the first frame update
    void Start()
    {
        _homeButton.onClick.AddListener(LoadMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadMenu()
    {
        GameStateManager.Instance.LoadScene(GameStateManager.Scene.MainMenu);
    }

}
