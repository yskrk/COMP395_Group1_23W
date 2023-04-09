using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{  
    public Transform plateSelector;
    
    public static int[] orderValue = { 1111111111, 1211111111, 1100000001 }; //digits represent position of each food item. For example bottom bun is 10000
    public static int[] plateValue = { 0, 0, 0 };
    public static float[] orderTimer = { 60, 60, 60 }; //Each order time

    public static int plateNum = 0; //moves plates
    public static int plateZpos = -1;

    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            plateNum += 1;
            plateZpos -= 2;

            if ( plateNum > 2)
            {
                plateNum = 0;
                plateZpos = -1;
            }

            orderTimer[0] -= Time.deltaTime;
            orderTimer[1] -= Time.deltaTime;
            orderTimer[2] -= Time.deltaTime;

            plateSelector.transform.position = new Vector3(0, 0, plateZpos);
        }    
    }
}
