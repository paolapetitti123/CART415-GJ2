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
    public GameObject keyAnimation;
    public Camera camera2;
    //public Image keyImage;
    public Sprite _Image;
    public GameObject character2;
    public bool isScared = false;
    public GameObject[] flashingGlow;
    public GameObject arrow;

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
        keyAnimation.SetActive(false);
        flashingGlow = GameObject.FindGameObjectsWithTag("glowKeys");

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
        //isScared = true;
        arrow.SetActive(true);
        StopFlashingAnimation();
        key.SetActive(false);

        //StartCoroutine(Scare());


    }

    public void StopFlashingAnimation()
    {
        foreach(GameObject flashingKeys in flashingGlow)
        {
            Animator flashingGlowAnim = flashingKeys.GetComponent<Animator>();

            flashingGlowAnim.Play("Flashing-stop");
        }
    }


    public void OnDrop()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.collider.tag == "lock")
            {
                arrow.SetActive(false);
                Debug.Log("Hitting the lock");
                keyAnimation.SetActive(true);
                Animator keyAnimator = keyAnimation.GetComponent<Animator>();

                GameObject character2 = GameObject.FindGameObjectWithTag("character2");
                Animator lookAnimator = character2.GetComponent<Animator>();

                if (character2 != null)
                {
                    lookAnimator.SetBool("isScared", true);
                    character2.transform.Rotate(0f, -45f, 0.0f, Space.Self);
                    Debug.Log("scare animation");

                    if (scareMeter != null)
                    {
                        scareMeter.ScareEvent();
                    }

                }



                //TODO: Trigger lock animation, then have the scare coroutine happen

            }
            else
            {
                Debug.Log("Not hitting the lock");
                transform.localPosition = Vector3.zero;
            }
            // key.SetActive(true);
            // key.transform.position = hit.point;
        }
    }
}
