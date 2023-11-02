using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    public GameObject toolBox;
    public GameObject hacksaw;

    // Start is called before the first frame update
    void Start()
    {
        toolBox.SetActive(true);
        hacksaw.GetComponent<BoxCollider>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Animator toolBoxOpen = toolBox.GetComponent<Animator>();

        toolBoxOpen.Play("open-toolbox");
        gameObject.GetComponent<AudioSource>().Play();

        StartCoroutine(showHacksaw());
    }

    private IEnumerator showHacksaw()
    {
        yield return new WaitForSeconds(2f);


        if(hacksaw != null && hacksaw.activeInHierarchy == true)
        {
            hacksaw.GetComponent<Animator>().Play("hacksaw-show");
            hacksaw.GetComponent<BoxCollider>().enabled = true;
        }
        else if(hacksaw.activeInHierarchy == false)
        {
            hacksaw.GetComponent<Animator>().enabled = false;
        }
    }
}
