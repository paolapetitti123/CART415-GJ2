using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory Inventory;


    // Start is called before the first frame update
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
        Inventory.ItemRemoved += Inventory_ItemRemoved;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");

        foreach (Transform slot in inventoryPanel)
        {
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>();

            ItemDrag itemDragHandler = imageTransform.GetComponent<ItemDrag>();

            if (!image.enabled) 
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                // TODO: Store a reference to the item
                itemDragHandler.Item = e.Item;

                break;
            }
        }
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        foreach(Transform slot in inventoryPanel)
        {
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            ItemDrag itemDragHandler = imageTransform.GetComponent<ItemDrag>();

            if (itemDragHandler.Item == e.Item)
            {
                image.enabled = false;
                image.sprite = null;
                

                break;
            }
        }
    }

    
}
