using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public Orders[] orders;
    public Transform plateSelector;
    // public static int[] orderValue = { 1111111111, 1211111111, 1100000001 }; //digits represent position of each food item. For example bottom bun is 10000
    // public static int[] plateValue = { 0, 0, 0 };
    // public static float[] orderTimer = { 60, 60, 60 }; //Each order time

    public int plateNum = 0; //moves plates
    public int plateZpos = -3;
    public int maxPlates = 3;
    public float minTime = 30;
    public float maxTime = 90;
    public Plate[] plates;
    // private bool waiting = false;
    void Start() {
    }

    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            plateNum = (++plateNum) % maxPlates;
            plateZpos = 3 + -3 * plateNum;
            plateSelector.position = new Vector3(0, 0, plateZpos);
        }
        else if ( Input.GetKeyDown( KeyCode.RightArrow ) ) {
            plateNum = (++plateNum) % maxPlates;
            plateZpos = 3 + -3 * plateNum;
            plateSelector.position = new Vector3(0, 0, plateZpos);
        }
        else if ( Input.GetKeyDown( KeyCode.LeftArrow ) ) {
            plateNum = (--plateNum) % maxPlates;
            if ( plateNum < 0 ) plateNum += maxPlates;
            plateZpos = 3 + -3 * plateNum;
            plateSelector.position = new Vector3(0, 0, plateZpos);
        }

        foreach ( Plate p in plates ) {
            if ( p.ordered == false ) {
                int x = UnityEngine.Random.Range(0,Orders.possibleOrders.Length);
                Debug.Log(x);
                p.OrderUp( x );
            }
        }
    }

    public float NextDistribution() {
        return UnityEngine.Random.Range(minTime,maxTime);
    }

    public void PutOnPlate( GameObject obj , FoodValues type ) {
        plates[plateNum].Recieve( obj , type );
    }

}
