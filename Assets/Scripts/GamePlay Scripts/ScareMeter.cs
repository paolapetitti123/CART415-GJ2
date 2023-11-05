using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScareMeter : MonoBehaviour
{

    public Image point1;
    public Image point2;
    public Image point3;
    public Image point4;
    public Image point5;
    public Image point6;
    public Image point7;

    public Image Ghost1;
    public Image Ghost2;
    public Image Ghost3;
    //  public Image point8;
    // public Image point9;
    // public Image point10;

    public int counter;
    int totalCounter; 


    // Start is called before the first frame update
    void Start()
    {

        point1.enabled = false;
        point2.enabled = false;
        point3.enabled = false;
        point4.enabled = false;
        point5.enabled = false;
        point6.enabled = false;
        point7.enabled = false;
        Ghost1.enabled = false;
        Ghost2.enabled = false;
        Ghost3.enabled = false;
        counter = 0;
        totalCounter = 0;
        GameObject scareMeter = GameObject.FindGameObjectWithTag("scareMeter");

        scareMeter.GetComponent<Animator>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScareCount()
    {
        Debug.Log("counter: " + counter);
        ScareEvent(counter + 1);
    }

    public void TutorialScareEvent()
    {
        Debug.Log("in scare event");

        point1.enabled = true;

        if (point1.enabled == true)
        {
            Debug.Log("enabled");
            counter = 1;
        }
        else
        {
            Debug.Log("not enabled");

        }
    }


 
    public void ScareEvent(int count)
    {
        if(totalCounter == 0)
        {
            totalCounter = 1;
        }

        totalCounter += count;
        Debug.Log("Total Count: " + totalCounter);
        GameObject scareMeter = GameObject.FindGameObjectWithTag("scareMeter");

        Animator scareAddAnimator = scareMeter.GetComponent<Animator>();

        if (totalCounter == 2)
        {
            //scareAddAnimator.SetBool("add", true);

            scareMeter.GetComponent<Animator>().enabled = true;

            scareMeter.GetComponent<Animator>().Play("pointAdd");
            Invoke("counter2", 2.0f);
            //StartCoroutine(Reset());


        }
        else if (totalCounter == 3)
        {
            //scareAddAnimator.SetBool("add", true);

            scareMeter.GetComponent<Animator>().Play("pointAdd");
            Invoke("counter3", 2.0f);
            //StartCoroutine(Reset());


        }
        else if (totalCounter == 4)
        {
            //scareAddAnimator.SetBool("add", true);

            scareMeter.GetComponent<Animator>().Play("pointAdd");
            Invoke("counter4", 2.0f);
            // Game win
            StartCoroutine(LoadGameWinScene());
        }
    }

    public void counter2()
    {
        point2.enabled = true;
        point3.enabled = true;
        Ghost1.enabled = true;
  
    }

    public void counter3()
    {
        point2.enabled = true;
        point3.enabled = true;
        point4.enabled = true;
        point5.enabled = true;
        Ghost1.enabled = true;
        Ghost2.enabled = true;
       
    }
    public void counter4()

    {
        point2.enabled = true;
        point3.enabled = true;
        point4.enabled = true;
        point5.enabled = true;
        point6.enabled = true;
        point7.enabled = true;
        Ghost1.enabled = true;
        Ghost2.enabled = true;
        Ghost3.enabled = true;
    }

    //private IEnumerator Reset()
    //{
    //    yield return new WaitForSeconds(3f);
    //    GameObject scareMeter = GameObject.FindGameObjectWithTag("scareMeter");
    //    Animator scareAddAnimator = scareMeter.GetComponent<Animator>();
    //    scareAddAnimator.SetBool("add", false);
    //}


    private IEnumerator LoadGameWinScene()
    {
        yield return new WaitForSeconds(3f);
        GameObject scareMeter = GameObject.FindGameObjectWithTag("scareMeter");
        Animator scareMeterAnimator = scareMeter.GetComponent<Animator>();
        scareMeterAnimator.SetBool("win", true);
        yield return new WaitForSeconds(4f);
        GameStateManager.Instance.LoadScene(GameStateManager.Scene.GameWin);

    }


}
