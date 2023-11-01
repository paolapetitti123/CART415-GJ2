using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassOfWater : MonoBehaviour, IInventoryItem
{
    public Sprite _Image = null;
    public GameObject water;
    public ScareMeter scareMeter;
    public GameObject animatedWater;


    public string Name
    {
        get
        {
            return "Cup of water";
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
        water.SetActive(true);
        //Get camera's MonoBehaviour
        animatedWater.SetActive(false);
        scareMeter.point1.enabled = true;
        scareMeter.counter = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPickup()
    {

        water.SetActive(false);
    }

    public void OnDrop()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 10000))
        {
            if (hit.collider.tag == "tv")
            {
                Invoke("Remove", 5.0f);

                //StartCoroutine(Remove());

                Debug.Log("Tag foud. Hitting the tv");
                animatedWater.SetActive(true);

                GameObject character2 = GameObject.FindGameObjectWithTag("character2");
                Animator characterAnimator = character2.GetComponent<Animator>();

                // add animator for tv

                if (character2 != null)
                {
                    // trigger character animation when chandelier falls

                    Debug.Log("scare animation for tv");

                    if (scareMeter != null)
                    {
                        scareMeter.ScareCount();
                        scareMeter.counter++;
                        


                    }

                }


            }
            else
            {
                Debug.Log("Not hitting the tv");
                transform.localPosition = Vector3.zero;
            }

        }

    }


    public void Remove()
    {
        animatedWater.SetActive(false);
        Debug.Log("water set to inactive");
    }


}
