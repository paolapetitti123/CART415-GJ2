using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorbell : MonoBehaviour
{
    private AudioSource doorBellAudio;
    public Animator doorAnimator;

    void Start()
    {
        doorBellAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Door clicked");
        doorBellAudio.Play();
        StartCoroutine(DoorOpen());
    }

    private IEnumerator DoorOpen()
    {
        yield return new WaitForSeconds(2f);
        GameObject door = GameObject.FindGameObjectWithTag("door");
        Animator doorAnimator = door.GetComponent<Animator>();

        if (door != null)
        {
            doorAnimator.SetBool("door-open", true);
            Debug.Log("Door animation");
        }

       // StartCoroutine(Look());
    }

    private IEnumerator Look()
    {
        yield return new WaitForSeconds(2f);
        GameObject character = GameObject.FindGameObjectWithTag("character");
        Animator lookAnimator = character.GetComponent<Animator>();

        if (character != null)
        {
            lookAnimator.SetBool("isOpen", true);
            Debug.Log("Look animation");
        }
    }
}
