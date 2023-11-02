using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureFrame : MonoBehaviour
{
    public Image  ghostLife1;
    public Image ghostLife2;
    public Image ghostLife3;


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

            if (ghostLife1.enabled)
            {
                ghostLife1.GetComponent<Animator>().Play("ghost-life-lost"); 
                
                
            }
            else if (ghostLife1.enabled == false && ghostLife2.enabled)
            {
                ghostLife2.GetComponent<Animator>().Play("ghost-life-lost");
                
                
            }
            else if (ghostLife1.enabled == false && 
                    ghostLife2.enabled == false && 
                    ghostLife3.enabled)
            {
                ghostLife3.GetComponent<Animator>().Play("ghost-life-lost");
               
                
                // GAME OVER
            }

        }
        
    }
}
