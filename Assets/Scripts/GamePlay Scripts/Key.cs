using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public GameObject key;
    public Image keyImage;
    public GameObject character2;
    public bool isScared = false;

    // Start is called before the first frame update
    void Start()
    {
        key.SetActive(true);
        keyImage.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Key clicked");
        keyImage.enabled = true;
        isScared = true;

        StartCoroutine(Scare());

    }

    private IEnumerator Scare()
    {
        key.SetActive(false);
        yield return new WaitForSeconds(.3f);
        GameObject character2 = GameObject.FindGameObjectWithTag("character2");
        Animator lookAnimator = character2.GetComponent<Animator>();

        if (character2 != null)
        {
            lookAnimator.SetBool("isScared", true);
            Debug.Log("scare animation");

        }
    }
}
