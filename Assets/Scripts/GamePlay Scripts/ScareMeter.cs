using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScareMeter : MonoBehaviour
{
    public Image point1;
    public Image point2;
    public Image point3;
    public Image point4;
    public Image point5;
    public Image point6;
    public Image point7;
    public Image point8;
    public Image point9;
    public Image point10;

    public int counter;

    // Start is called before the first frame update
    void Start()
    {
        point1.enabled = false;
        point2.enabled = false;
        point3.enabled = false;
        point4.enabled = false;
        point5.enabled = false;
        point6.enabled = false;
        point7.enabled = false;
        point8.enabled = false;
        point9.enabled = false;
        point10.enabled = false;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TutorialScareEvent()
    {
        Debug.Log("in scare event");

        point1.enabled = true;

        if (point1.enabled == true)
        {
            Debug.Log("enabled");
            counter++;
        }
        else
        {
            Debug.Log("not enabled");

        }
    }


 
    public void ScareEvent()
    {
        Debug.Log("in scare event");
        
        if(counter == 1)
        {
            point2.enabled = true;
            counter = 2;
        
        }
        else if(counter == 2)
        {
            point3.enabled = true;
            counter = 3;
        }
        else if (counter == 3)
        {
            point4.enabled = true;
            counter = 4;
        }
        else if (counter == 4)
        {
            point5.enabled = true;
            counter = 5;
        }
        else if (counter == 5)
        {
            point6.enabled = true;
            counter = 6;
        }
        else if (counter == 6)
        {
            point7.enabled = true;
            counter = 7;
        }
        else if (counter == 7)
        {
            point8.enabled = true;
            counter = 8;
        }
        else if (counter == 8)
        {
            point9.enabled = true;
            counter = 9;
        }
        else if (counter == 9)
        {
            point10.enabled = true;

            // Game win
        }
    }


}
