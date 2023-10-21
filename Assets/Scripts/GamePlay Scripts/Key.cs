using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public GameObject key;
    public Image keyImage;

    // Start is called before the first frame update
    void Start()
    {
        key.SetActive(true);
        keyImage.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Key clicked");
        key.SetActive(false);
        keyImage.enabled = true;



    }
}
