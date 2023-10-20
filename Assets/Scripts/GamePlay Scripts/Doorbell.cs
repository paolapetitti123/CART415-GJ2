using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorbell : MonoBehaviour
{
    private AudioSource doorBellAudio;
    public Animator doorAnimator;

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

        if (door != null)
        {
            doorAnimator.SetBool("Open", true);
            Debug.Log("animation");



        }
    }
}
         