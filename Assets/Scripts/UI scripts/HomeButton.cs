using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    public string home; 

    public void SwitchScene()
    {
        SceneManager.LoadScene(home);
    }
}
