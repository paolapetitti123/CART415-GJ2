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
            Debug.Log("Item dropping");
            IInventoryItem item = eventData.pointerDrag.gameObject.GetComponent<ItemDrag>().Item;

            if(item != null)
            {
                _Inventory.RemoveItem(item);
                item.OnDrop();
            }
        }
    }
}
