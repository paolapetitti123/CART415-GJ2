using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZippoLighter : MonoBehaviour, IInventoryItem
{
    public Sprite _Image = null;

    public string Name
    {
        get
        {
            return "zippo-lighter";
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

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
