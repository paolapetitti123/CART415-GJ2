using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour
{
    public string replay; 

    public void SwitchScene()
    {
        SceneManager.LoadScene(replay);
    }
}
