using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float rayLength;
    public LayerMask layerMask;
    public Inventory inventory;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray rayMain = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(rayMain, out hit, rayLength, layerMask))
            {
                if (hit.collider.enabled)
                {
                    IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
                    if(item != null)
                    {
                        inventory.AddItem(item);
                        Debug.Log("Item: " + item + "added");
                    }
                    Debug.Log(hit.collider.name);

                }
            }
        }
    }


}
