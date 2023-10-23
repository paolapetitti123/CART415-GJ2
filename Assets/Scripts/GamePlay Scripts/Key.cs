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
        //key.SetActive(false);
        /* TODO: 1. make keys disappear
         *       2. play keys pickup sound (maybe)
         *       3. when the key hits the look, trigger the lock animation
         *       4. trigger character scare animation either while or after lock animation
         */
        StartCoroutine(Scare());
      

    }

    private IEnumerator Scare()
    {
        Debug.Log("in scare");
       // yield return new WaitForSeconds(.3f);
        GameObject character2 = GameObject.FindGameObjectWithTag("character2");
        Animator lookAnimator = character2.GetComponent<Animator>();



        if (character2 != null)
        {   key.SetActive(false);
            Debug.Log("not null");
            lookAnimator.SetBool("isScared", true);
            yield return new WaitForSeconds(4f);
            character2.transform.Rotate(0f, 180f, 0.0f, Space.Self);
            Debug.Log("scare animation");
            

            if (scareMeter != null)
            {
                scareMeter.ScareEvent();
            }

        }
    }

    public void OnDrop()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 100))
        {
            if(hit.collider.tag == "lock")
            {
                Debug.Log("Hitting the lock");
            }

           // key.SetActive(true);
            // key.transform.position = hit.point;
        }
    }
}
