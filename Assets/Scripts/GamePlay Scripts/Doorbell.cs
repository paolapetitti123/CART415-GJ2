using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorbell : MonoBehaviour
{
    private AudioSource doorBellAudio;
    public Animator doorAnimator;
<<<<<<< HEAD
<<<<<<< HEAD
=======
    public Animator lookAnimator;
>>>>>>> 6e49f0332ccea76b61fc636f3e33d27090929f40
=======
>>>>>>> parent of 75d75faf (win state)

    // Start is called before the first frame update
    void Start()
    {
        doorBellAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Debug.Log("Door clicked");
        doorBellAudio.Play();
        // Wait for 2 seconds before door opens
        StartCoroutine(DoorOpen());
    }


    private IEnumerator DoorOpen()
    {
        yield return new WaitForSeconds(2f);
        GameObject door = GameObject.FindGameObjectWithTag("door");
        Animator doorAnimator = door.GetComponent<Animator>();

<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of 75d75faf (win state)
        if (door != null)
        {
            doorAnimator.SetBool("Open", true);
            Debug.Log("animation");



        }
    }
}
<<<<<<< HEAD
         
=======

        if (door != null)
        {
            doorAnimator.SetBool("door-open", true);
            Debug.Log("animation");
            StartCoroutine(Look());
        }
    }

    private IEnumerator Look()
    {
        yield return new WaitForSeconds(2f);
        GameObject character = GameObject.FindGameObjectWithTag("character");
        Animator lookAnimator = character.GetComponent<Animator>();


        if (character != null)
        {
            lookAnimator.SetBool("isOpen", true);
            Debug.Log("animation");
        }
    }
}
>>>>>>> 6e49f0332ccea76b61fc636f3e33d27090929f40
=======
         
>>>>>>> parent of 75d75faf (win state)
