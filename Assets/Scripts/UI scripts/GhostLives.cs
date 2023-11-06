using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostLives : MonoBehaviour
{

    public static GhostLives Instance;
    // Start is called before the first frame update
    
    public Image ghostLife1;
    public Image ghostLife2;
    public Image ghostLife3;

    public Image ghostLost1;
    public Image ghostLost2;
    public Image ghostLost3;

    public GameObject failOverlayObject;
    public GameObject ghostContainer;
    int totalCounter;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        totalCounter = 0;
        failOverlayObject.SetActive(false);

    }
    public void GhostLivesCounter(int counter)
    {
       totalCounter += counter;
        Debug.Log(totalCounter);
        if(totalCounter == 1)
        {
            
            ghostLife1.GetComponent<Animator>().Play("ghost-life-lost");
            failOverlayObject.SetActive(true);
            failOverlayObject.GetComponent<Animator>().Play("fail-anim");
            ghostContainer.GetComponent<Animator>().Play("ghost-lives-lost-bigger");
            StartCoroutine(GhostLifeLost(ghostLife1, ghostLost1));
            
        }
        else if(totalCounter == 2)
        {
            
            ghostLife2.GetComponent<Animator>().Play("ghost-life-lost");
            failOverlayObject.SetActive(true);
            failOverlayObject.GetComponent<Animator>().Play("fail-anim");
            

            StartCoroutine(GhostLifeLost(ghostLife2, ghostLost2));
        }
        else if(totalCounter == 3)
        {
            
            ghostLife3.GetComponent<Animator>().Play("ghost-life-lost");
            failOverlayObject.SetActive(true);
            failOverlayObject.GetComponent<Animator>().Play("fail-anim");

            StartCoroutine(GhostLifeLost(ghostLife3, ghostLost3));

            StartCoroutine(LoadGameOverScene());
            // gameover
        }
    }

    private IEnumerator GhostLifeLost(Image life, Image lost)
    {
        yield return new WaitForSeconds(1f);
        life.enabled = true;
        lost.enabled = false;
        failOverlayObject.SetActive(false);
        
    }

    private IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(3f);

        GameStateManager.Instance.LoadScene(GameStateManager.Scene.GameOver);

    }
}
