using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    public GameObject toolBox;

    // Start is called before the first frame update
    void Start()
    {
        toolBox.SetActive(true);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Animator toolBoxOpen = toolBox.GetComponent<Animator>();

        toolBoxOpen.Play("open-toolbox");

        StartCoroutine(showHacksaw());
    }

    private IEnumerator showHacksaw()
    {
        yield return new WaitForSeconds(2f);

        GameObject hacksaw = GameObject.FindGameObjectWithTag("hacksaw");
        Animator hacksawAnimator = hacksaw.GetComponent<Animator>();

        if(hacksaw != null)
        {
            hacksawAnimator.Play("hacksaw-show");
        }
    }
}
