using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameFlow : MonoBehaviour
{
    public Orders[] orders;
    public Transform plateSelector;
    public GameObject pan;
    // public static int[] orderValue = { 1111111111, 1211111111, 1100000001 }; //digits represent position of each food item. For example bottom bun is 10000
    // public static int[] plateValue = { 0, 0, 0 };
    // public static float[] orderTimer = { 60, 60, 60 }; //Each order time

    public int plateNum = 0; //moves plates
    public int plateZpos = -3;
    public int maxPlates = 3;
    public float minTime = 30;
    public float maxTime = 90;
    public float maxGameTime = 300;
    public GameObject cookingFX;
    public Image timer;
    public Plate[] plates;
    public int lives = 3;

    void Start() {
    }

    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            plates[plateNum].Deactivate();
            plateNum = (++plateNum) % maxPlates;
            plateZpos = 3 + -3 * plateNum;
            plateSelector.position = new Vector3(0, 0, plateZpos);
            plates[plateNum].Activate();
        }
        else if ( Input.GetKeyDown( KeyCode.RightArrow ) ) {
            plates[plateNum].Deactivate();
            plateNum = (++plateNum) % maxPlates;
            plateZpos = 3 + -3 * plateNum;
            plateSelector.position = new Vector3(0, 0, plateZpos);
            plates[plateNum].Activate();
        }
        else if ( Input.GetKeyDown( KeyCode.LeftArrow ) ) {
            plates[plateNum].Deactivate();
            plateNum = (--plateNum) % maxPlates;
            if ( plateNum < 0 ) plateNum += maxPlates;
            plateZpos = 3 + -3 * plateNum;
            plateSelector.position = new Vector3(0, 0, plateZpos);
            plates[plateNum].Activate();
        }

        foreach ( Plate p in plates ) {
            if ( p.ordered == false ) {
                int x = UnityEngine.Random.Range(0,Orders.possibleOrders.Length);
                p.OrderUp( x , NextDistribution() );
            }
        }
    }

    public float NextDistribution() {
        return UnityEngine.Random.Range(minTime,maxTime);
    }

    public void PutOnPlate( GameObject obj , FoodValues type ) {
        plates[plateNum].Recieve( obj , type );
    }

    public void PutOnPan( GameObject obj ) {
        GameObject patty = Instantiate( obj , new Vector3( -2.75f , 1f , 0.6f ) , Quaternion.identity , parent: pan.transform );
        Clickfood cf = patty.GetComponent<Clickfood>();
        cf.StartCoroutine("Cook");
    }

}
