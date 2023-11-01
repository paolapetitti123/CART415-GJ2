using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacksaw : MonoBehaviour, IInventoryItem
{
    public Sprite _Image = null;
    public ScareMeter scareMeter;
    public GameObject hacksaw;
    public GameObject chandelier;


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
        scareMeter.point1.enabled = true;
        scareMeter.counter = 1;
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
                Animator characterAnimator = character2.GetComponent<Animator>();

                // add animator for chandelier
                
                if (character2 != null)
                {
                    // trigger character animation when chandelier falls

                    Debug.Log("scare animation");

                    if (scareMeter != null)
                    {
                        scareMeter.ScareCount(); 
                        
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


        if (hacksaw != null && hacksaw.activeInHierarchy == true)
        {
            hacksaw.GetComponent<Animator>().Play("hacksaw-inUse");
            hacksaw.GetComponent<BoxCollider>().enabled = true;
            StartCoroutine(Fall());
            Debug.Log("cutting the chandelier");


        }
        else if (hacksaw.activeInHierarchy == false)
        {
            hacksaw.GetComponent<Animator>().enabled = false;
        }
    }
    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(2f);
        hacksaw.SetActive(false);
        Animator chandelierAnimator = chandelier.GetComponent<Animator>();
        chandelierAnimator.SetBool("isCut", true);
        Debug.Log("falling chandelier");



    }


}
