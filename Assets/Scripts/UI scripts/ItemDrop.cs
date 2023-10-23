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

            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (item != null && hit.collider.tag == "lock")
                {
                    _Inventory.RemoveItem(item);
                    item.OnDrop();
                }
            }
        }
    }
}
