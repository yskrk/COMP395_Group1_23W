using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameFlow : MonoBehaviour
{
    public Transform plateSelector;
    public GameObject pan;
    public int plateNum = 0; //moves plates
    public int plateZpos = -3;
    public int maxPlates = 3;
    public float minTime = 30;
    public float maxTime = 90;
    public float currentGameTime = 0;
    public float maxGameTime = 300;
    public GameObject cookingFX;
    public Image timer;
    public Plate[] plates;
    public int lives = 10;
    public int maxLives = 10;
    public int score = 0;
    public TextMeshProUGUI[] texts;

    void Start() {

    }

    void Update()
    {
        currentGameTime += Time.deltaTime;
        timer.fillAmount = Mathf.Clamp( currentGameTime / (maxGameTime / 0.67f) , 0f , 0.67f );
        if (Input.GetKeyDown("tab"))
        {
            plates[plateNum].Deactivate();
            plateNum = (++plateNum) % maxPlates;
            plateSelector.position = plates[plateNum].transform.position;
            plates[plateNum].Activate();
        }
        else if ( Input.GetKeyDown( KeyCode.RightArrow ) ) {
            plates[plateNum].Deactivate();
            plateNum = (++plateNum) % maxPlates;
            plateSelector.position = plates[plateNum].transform.position;
            plates[plateNum].Activate();
        }
        else if ( Input.GetKeyDown( KeyCode.LeftArrow ) ) {
            plates[plateNum].Deactivate();
            plateNum = (--plateNum) % maxPlates;
            if ( plateNum < 0 ) plateNum += maxPlates;
            plateSelector.position = plates[plateNum].transform.position;
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

    public void Score( int points ) {
        score += points;
        texts[1].SetText( score.ToString() );
    }

    public void Damage() {
        lives--;
        texts[0].SetText( lives.ToString() + " / " + maxLives );
    }

    IEnumerator Countdown() {
        yield return new WaitForSeconds( 0 );
    }

}
