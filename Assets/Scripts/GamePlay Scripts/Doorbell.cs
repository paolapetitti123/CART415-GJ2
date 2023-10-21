using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorbell : MonoBehaviour
{
    private AudioSource doorBellAudio;
    public Animator doorOpenAnimator;
    public Animator lookAnimator;
    public Animator ghostAnimator;

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
        Debug.Log("Door OPEN");

        yield return new WaitForSeconds(2f);
        GameObject door = GameObject.FindGameObjectWithTag("door");
        Animator doorOpenAnimator = door.GetComponent<Animator>();

        if (door != null)
        {
            doorOpenAnimator.SetBool("isOpen", true);
            Debug.Log("Door open animation");
        }

        StartCoroutine(Look());
        StartCoroutine(Ghost());


    }

        private IEnumerator Look()
    {
        yield return new WaitForSeconds(.3f);
        GameObject character = GameObject.FindGameObjectWithTag("character");
        Animator lookAnimator = character.GetComponent<Animator>();

        if (character != null)
        {
            lookAnimator.SetBool("Look", true);
            Debug.Log("Look animation");
        }
    }

    private IEnumerator Ghost()
    {
        Debug.Log("ghost enter");

        yield return new WaitForSeconds(4f);
        GameObject ghost = GameObject.FindGameObjectWithTag("ghost");
        Animator ghostAnimator = ghost.GetComponent<Animator>();

        if (ghost != null)
        {
            ghostAnimator.SetBool("isOpen", true);
            Debug.Log("ghost animation");
        }

    }
}
