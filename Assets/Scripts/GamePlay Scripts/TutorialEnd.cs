using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(LoadGameplayScene());
        }
    }

    private IEnumerator LoadGameplayScene()
    {
        yield return new WaitForSeconds(5f);

        GameStateManager.Instance.LoadScene(GameStateManager.Scene.GamePlay);

    }
}
