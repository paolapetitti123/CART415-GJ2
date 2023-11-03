using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LightOne;
    public GameObject LightTwo;
    int counter;

    void Start()
    {
        counter = 0;
    }

    private void OnMouseDown()
    {
        Debug.Log("Light click");
        LightOne.GetComponent<Animator>().Play("light-flicker");
        LightTwo.GetComponent<Animator>().Play("light-flicker");

        if (counter == 0)
        {
            int lifeLost = 1;
            GhostLives.Instance.GhostLivesCounter(lifeLost);
            counter = 1;
        }

        StartCoroutine(StopFlashing());
    }

    private IEnumerator StopFlashing()
    {
        yield return new WaitForSeconds(2f);

        LightOne.GetComponent<Animator>().Play("light-idle");
        LightTwo.GetComponent<Animator>().Play("light-idle");
    }
}
