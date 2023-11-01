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

    public void ScareCount()
    {
        Debug.Log("counter: " + counter);
        ScareEvent(counter + 1);
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


 
    public void ScareEvent(int count)
    {
        Debug.Log("in scare event");
        
        if(count == 2)
        {
            //    point2.enabled = true;


            //}
            //else if(counter == 3)
            //{
            //    point2.enabled = true;
            //    point3.enabled = true;

            //}
            //else if (counter == 4)
            //{
            point2.enabled = true;
            point3.enabled = true;
            point4.enabled = true;
            
        }
        else if (counter == 3)
        {
        //    point2.enabled = true;
        //    point3.enabled = true;
        //    point4.enabled = true;
        //    point5.enabled = true;
            
        //}
        //else if (counter == 6)
        //{
        //    point2.enabled = true;
        //    point3.enabled = true;
        //    point4.enabled = true;
        //    point5.enabled = true;
        //    point6.enabled = true;
            
        //}
        //else if (counter == 7)
        //{
            point2.enabled = true;
            point3.enabled = true;
            point4.enabled = true;
            point5.enabled = true;
            point6.enabled = true;
            point7.enabled = true;
            
        }
        else if (counter == 4)
        {
        //    point2.enabled = true;
        //    point3.enabled = true;
        //    point4.enabled = true;
        //    point5.enabled = true;
        //    point6.enabled = true;
        //    point7.enabled = true;
        //    point8.enabled = true;
            
        //}
        //else if (counter == 9)
        //{
        //    point2.enabled = true;
        //    point3.enabled = true;
        //    point4.enabled = true;
        //    point5.enabled = true;
        //    point6.enabled = true;
        //    point7.enabled = true;
        //    point8.enabled = true;
        //    point9.enabled = true;
            
        //}
        //else if (counter == 10)
        //{
            point2.enabled = true;
            point3.enabled = true;
            point4.enabled = true;
            point5.enabled = true;
            point6.enabled = true;
            point7.enabled = true;
            point8.enabled = true;
            point9.enabled = true;
            point10.enabled = true;

            // Game win
        }
    }


}
