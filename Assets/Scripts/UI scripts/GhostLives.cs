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
    int totalCounter;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        totalCounter = 0;
    }
    public void GhostLivesCounter(int counter)
    {
        totalCounter += counter;
        if(totalCounter == 1)
        {
            ghostLife1.GetComponent<Animator>().Play("ghost-life-lost");

            StartCoroutine(GhostLifeLost(ghostLife1, ghostLost1));
        }
        else if(totalCounter == 2)
        {
            ghostLife2.GetComponent<Animator>().Play("ghost-life-lost");

            StartCoroutine(GhostLifeLost(ghostLife2, ghostLost2));
        }
        else if(totalCounter == 4)
        {
            ghostLife3.GetComponent<Animator>().Play("ghost-life-lost");

            StartCoroutine(GhostLifeLost(ghostLife3, ghostLost3));

            // gameover
        }
    }

    private IEnumerator GhostLifeLost(Image life, Image lost)
    {
        yield return new WaitForSeconds(1f);
        life.enabled = true;
        lost.enabled = false;
       
    }
}
