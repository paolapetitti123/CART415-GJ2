using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAudioManager : MonoBehaviour
{
    private AudioSource keyPickUpAudio;
    // Start is called before the first frame update
    void Start()
    {
        keyPickUpAudio = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        keyPickUpAudio.Play();
    }
}
