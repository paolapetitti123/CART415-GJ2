using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrop : MonoBehaviour, IDropHandler
{
    public Inventory _Inventory;

    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invPanel = transform as RectTransform;

        if(!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {
            
            IInventoryItem item = eventData.pointerDrag.gameObject.GetComponent<ItemDrag>().Item;

            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.Log(item.Name + " dropping from inventory");

            if (Physics.Raycast(ray, out hit, 100))
            {
                if(item != null)
                {
                    // tutorial
                    if(hit.collider.tag == "lock" && item.Name == "keys")
                    {
                        _Inventory.RemoveItem(item);
                        item.OnDrop();
                    }
                    // living room
                    else if (hit.collider.tag == "chandelier" && item.Name == "Hacksaw")
                    {
                        _Inventory.RemoveItem(item);
                        item.OnDrop();
                    }
                    else if (hit.collider.tag == "candle" && item.Name == "Lighter")
                    {
                        _Inventory.RemoveItem(item);
                        item.OnDrop();
                    }
                    else if (hit.collider.tag == "tv" && item.Name == "Cup of water")
                    {
                        _Inventory.RemoveItem(item);
                        item.OnDrop();
                    }
                    else if (hit.collider.tag == "cdPlayer" && item.Name == "CDObject")
                    {
                        _Inventory.RemoveItem(item);
                        item.OnDrop();
                    }

                    // next room
                    // next room
                }
                
            }
        }
    }
}
