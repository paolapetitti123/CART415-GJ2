using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacksaw : MonoBehaviour, IInventoryItem
{
    public Sprite _Image = null;
    public Camera mainCamera;
    public Camera scareCamera;
    public ScareMeter scareMeter;
    public GameObject hacksaw;
    public GameObject chandelier;
    int ifCounter;

    public string Name
    {
        get
        {
            return "Hacksaw";
        }
    }

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        scareCamera.enabled = false;
        scareMeter.point1.enabled = true;
        scareMeter.counter = 1;
        ifCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPickup()
    {
        gameObject.SetActive(false);
    }

    public void OnDrop()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 10000))
        {
            if (hit.collider.tag == "chandelier")
            {
              
                gameObject.SetActive(true);

                StartCoroutine(cutHacksaw());

                Debug.Log("Hitting the chandelier");
                GameObject character2 = GameObject.FindGameObjectWithTag("character2");

                // add animator for chandelier

                if (character2 != null)
                {
                    // trigger character animation when chandelier falls
                    

                   

                    Debug.Log("scare animation");

                    if (scareMeter != null)
                    {
                        if (ifCounter == 0)
                        {
                            int scareCount = 1;
                            //scareMeter.ScareCount();
                            scareMeter.ScareEvent(scareCount);
                            //scareMeter.counter++;
                            ifCounter = 1;
                        }

                    }

                }

            }
            else
            {
                Debug.Log("Not hitting the chandelier");
                transform.localPosition = Vector3.zero;
            }

        }
    }

    private IEnumerator cutHacksaw()
    {
        yield return new WaitForSeconds(0f);

        mainCamera.enabled = false;
        scareCamera.enabled = true;

        if (hacksaw != null && hacksaw.activeInHierarchy == true)
        {
            hacksaw.GetComponent<Animator>().enabled = true;
            hacksaw.GetComponent<Animator>().Play("hacksaw-inUse");
            hacksaw.GetComponent<BoxCollider>().enabled = true;
            StartCoroutine(Fall());
            Debug.Log("cutting the chandelier");


        }
        else if (hacksaw != null && hacksaw.activeInHierarchy == false)
        {
            Debug.Log("hacksaw not showing up for some reason so I'm here in it's place"); 
        }
    }
    private IEnumerator Fall()
    {
       
        yield return new WaitForSeconds(1.5f);
        mainCamera.enabled = true;
        scareCamera.enabled = false;
        Animator chandelierAnimator = chandelier.GetComponent<Animator>();
        chandelierAnimator.SetBool("isCut", true);
        Debug.Log("falling chandelier");
        hacksaw.SetActive(false);
       
        GameObject character2 = GameObject.FindGameObjectWithTag("character2");
        Animator characterAnimator = character2.GetComponent<Animator>();
        characterAnimator.Play("sitting-dodge");


    }

}
