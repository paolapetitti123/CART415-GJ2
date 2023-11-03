using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureFrame : MonoBehaviour
{
    int counter;

    public void Start()
    {
        counter = 0;
    }
    private void OnMouseDown()
    {
        gameObject.GetComponent<Animator>().enabled = true;
        gameObject.GetComponent<Animator>().Play("painting-fall");

        StartCoroutine(PaintingDropSound());
    }

    private IEnumerator PaintingDropSound()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<AudioSource>().Play();

        //gameObject.SetActive(false);

        GameObject character2 = GameObject.FindGameObjectWithTag("character2");
        Animator characterAnimator = character2.GetComponent<Animator>();

        // add animator for chandelier
        
        if (character2 != null)
        {
            // trigger character animation when chandelier falls
            characterAnimator.Play("sitting-to-disbelief");
            if (counter == 0)
            {
                int lifeLost = 1;
                GhostLives.Instance.GhostLivesCounter(lifeLost);
                counter = 1;
            }
            

        }
        
    }

}
