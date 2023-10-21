using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public ScareMeter scareMeter;
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
        Debug.Log("in scare");
        yield return new WaitForSeconds(.3f);
        GameObject character2 = GameObject.FindGameObjectWithTag("character2");
        Animator lookAnimator = character2.GetComponent<Animator>();



        if (character2 != null)
        {
            Debug.Log("not null");
            lookAnimator.SetBool("isScared", true);
            yield return new WaitForSeconds(4f);
            character2.transform.Rotate(0f, 180f, 0.0f, Space.Self);
            Debug.Log("scare animation");
            key.SetActive(false);

            if (scareMeter != null)
            {
                scareMeter.ScareEvent();
            }

        }
    }
}
