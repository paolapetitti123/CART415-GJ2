using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Inventory : MonoBehaviour
{
    private const int SLOTS = 4;

    private List<IInventoryItem> mItems = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public float rayLength;

    public LayerMask layerMask;

    public void AddItem(IInventoryItem item)
    {
        if(mItems.Count < SLOTS && Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray rayMain = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(rayMain, out hit, rayLength, layerMask))
            {
                if (hit.collider.enabled)
                {
                    Debug.Log(hit.collider.name);
                    mItems.Add(item);

                    item.OnPickup();

                    if (ItemAdded != null)
                    {
                        ItemAdded(this, new InventoryEventArgs(item));
                    }
                }
            }
        }
    }
}
