using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacksaw : MonoBehaviour, IInventoryItem
{
    public Sprite _Image = null;
    public ScareMeter scareMeter;

    public string Name
    {
        get
        {
            return "hacksaw";
        }
    }

    public Sprite Image
    {
        get
        {
            return _Image;
        }
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
                        scareMeter.ScareEvent();

                    }

                }

            }
            else
            {
                Debug.Log("Not hitting the lock");
                transform.localPosition = Vector3.zero;
            }

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

}
