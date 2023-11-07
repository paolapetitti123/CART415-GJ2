using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlassOfWater : MonoBehaviour, IInventoryItem
{
    public Sprite _Image = null;
    public Camera mainCamera;
    public Camera scareCamera;
    public GameObject water;
    public ScareMeter scareMeter;
    public GameObject animatedWater;
    public RawImage tvWorking;
    public RawImage tvBroken;
    int ifCounter;
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
        mainCamera.enabled = true;
        scareCamera.enabled = false;
        water.SetActive(true);
        //Get camera's MonoBehaviour
        animatedWater.SetActive(false);
        //scareMeter.point1.enabled = true;
        //scareMeter.counter = 1;

        tvBroken.GetComponent<RawImage>().enabled = false;
        tvWorking.GetComponent<RawImage>().enabled = true;

        ifCounter = 0;
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
                mainCamera.enabled = false;
                scareCamera.enabled = true;
                Invoke("CamSwitch", 4.0f);

                Invoke("Remove", 5.0f);


                Debug.Log("Tag foud. Hitting the tv");
                animatedWater.SetActive(true);

                Invoke("TVBreaking", 1.5f);
                GameObject character2 = GameObject.FindGameObjectWithTag("character2");
                Animator characterAnimator = character2.GetComponent<Animator>();

                characterAnimator.Play("sitting-to-stand-scared");



            }
            else if (hit.collider.tag == "RecycleBin")
            {
                GameObject Trashbin = GameObject.FindGameObjectWithTag("RecycleBin");
                water.SetActive(true);
                Trashbin.GetComponent<AudioSource>().Play();
            }
            else
            {
                Debug.Log("Not hitting the tv");
                transform.localPosition = Vector3.zero;
            }
        }
    }

    public void TVBreaking()
    {
        tvWorking.GetComponent<RawImage>().enabled = false;
        tvBroken.GetComponent<RawImage>().enabled = true;
        
    }


    public void Remove()
    {
        animatedWater.SetActive(false);
        Debug.Log("water set to inactive");
    }



    public void CamSwitch()
    {
        Debug.Log("in cam switch");
        mainCamera.enabled = true;
        scareCamera.enabled = false;
        GameObject character2 = GameObject.FindGameObjectWithTag("character2");
        Animator characterAnimator = character2.GetComponent<Animator>();

//        characterAnimator.Play("sitting-to-stand-scared");
        if (character2 != null)
        {
            // trigger character animation when chandelier falls

            Debug.Log("scare animation for tv");
            
            if (scareMeter != null)
            {
                if (ifCounter == 0)
                {
                    Debug.Log("In Glass of Water Scare Counter");
                    int scareCount = 1;
                    //scareMeter.ScareCount();
                    scareMeter.ScareEvent(scareCount);
                    //scareMeter.counter++;
                    ifCounter = 1;
                }

            }
        }

    }
}