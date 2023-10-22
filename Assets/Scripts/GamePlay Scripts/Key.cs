using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour, IInventoryItem
{
    public ScareMeter scareMeter;
    public GameObject key;
    public Camera camera2;
    //public Image keyImage;
    public Sprite _Image;
    public GameObject character2;
    public bool isScared = false;

    // Start is called before the first frame update

    public string Name
    {
        get
        {
            return "keys";
        }
    }

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    void Start()
    {
        key.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (camera2.enabled)
        {
            key.GetComponent<BoxCollider>().enabled = true;

        }
        else
        {
            key.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void OnPickup()
    {
        

        isScared = true;

        StartCoroutine(Scare());
        //key.SetActive(false);

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
