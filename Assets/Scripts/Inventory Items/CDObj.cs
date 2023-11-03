using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDObj : MonoBehaviour, IInventoryItem
{
    public Sprite _Image = null;
    public GameObject cdShow;

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
                gameObject.SetActive(true);
                gameObject.transform.position = new Vector3(0f, 0f, 0f);

                Debug.Log(" hitting the player");
                int lifeLost = 1;

                GhostLives.Instance.GhostLivesCounter(lifeLost);


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
    }

}
