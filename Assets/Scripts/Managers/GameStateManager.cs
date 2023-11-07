using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    /* Allows for easier access to all hte scenes available in the game and we can add and remove as needed,
     * 
     * Note that the order and names need to match the build settings scenes list though!
     */
    public enum Scene
    {
        MainMenu,
        Intro,
        Tutorial,
        GamePlay,
        GameWin,
        GameOver,
        GameCredits, 
        GameWinCredits,
        GameLoseCredits
    }

    /* Whenever a new scene needs to be loaded, this method can be called in any script
     * using the GameStateManager Instance. 
     * 
     * Look at the MainMenuUI script, to see how that's done on the click of a button if 
     * unsure what to do.
     */
    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString()); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
