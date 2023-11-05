using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDObj : MonoBehaviour, IInventoryItem
{
    public Sprite _Image = null;
    public GameObject cdShow;
    [SerializeField] public AudioSource musicSFX;
    int counter;

    public string Name
    {
        get
        {
            return "CDObject";
        }
    }

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void OnDrop()
    {   
        
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100000))
        {
            if (hit.collider.tag == "cdPlayer")
            {
                
                 cdShow.SetActive(true);
                
                GameObject character2 = GameObject.FindGameObjectWithTag("character2");
                Animator characterAnimator = character2.GetComponent<Animator>();
                musicSFX.Play();

                Debug.Log(" hitting the player");
                
                if(counter == 0)
                {
                    int lifeLost = 1;
                    GhostLives.Instance.GhostLivesCounter(lifeLost);
                    counter = 1;
                }
                if (character2 != null)
                {
                    characterAnimator.Play("sitting-not-phased");
                }




            }
            else
            {
                Debug.Log("Not hitting the player");
                transform.localPosition = Vector3.zero;
            }
        }
    }



    public void OnPickup()
    {
        gameObject.SetActive(false);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject cdShow = GameObject.FindGameObjectWithTag("cdShow");

        cdShow.SetActive(false);

        counter = 0; // this is to make sure the ghost lives lost gets called only once
    }

}
