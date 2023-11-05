using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorbell : MonoBehaviour
{
    private AudioSource doorBellAudio;
    [SerializeField] public AudioSource doorOpenAudio;
    public GameObject character;
    public GameObject character2;
    public bool isScared = false;
    public Animator doorOpenAnimator;
    public Animator lookAnimator;
    public Animator ghostAnimator;
    public Camera mainCamera;
    public Camera camera2;



    void Start()
    {
        doorBellAudio = GetComponent<AudioSource>();
        mainCamera.enabled = true;
        camera2.enabled = false;
        character.SetActive(true);
        character2.SetActive(false);

    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Door clicked");
        doorBellAudio.Play();

        GameObject flashingGlow = GameObject.FindGameObjectWithTag("glow");
        Animator flashingGlowAnim = flashingGlow.GetComponent<Animator>();

        flashingGlowAnim.Play("Flashing-stop");
        StartCoroutine(DoorOpen());
    }

    private IEnumerator DoorOpen()
    {
        Debug.Log("Door OPEN");
        yield return new WaitForSeconds(2f);


        GameObject door = GameObject.FindGameObjectWithTag("door");
        Animator doorOpenAnimator = door.GetComponent<Animator>();
        doorOpenAudio.Play();

        if (door != null)
        {
            doorOpenAnimator.SetBool("isOpen", true);
            Debug.Log("Door open animation");
        }

        StartCoroutine(Look());
        StartCoroutine(Ghost());
        StartCoroutine(CameraSwitch());

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

    private IEnumerator CameraSwitch()
    {
        yield return new WaitForSeconds(8f);
        mainCamera.enabled = false;
        camera2.enabled = true;
        character.SetActive(false);
        character2.SetActive(true);
    }
}
