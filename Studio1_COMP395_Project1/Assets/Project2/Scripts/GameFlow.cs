using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    [SerializeField] private Transform plateSelector;
    [SerializeField] private Image timer;
    [SerializeField] private Plate[] plates;
    [SerializeField] private GameObject pan;
    [SerializeField] private TextMeshProUGUI[] texts;
    private int plateNum = 0; //moves plates
    private int maxPlates = 3;
    [SerializeField] private float[] timeRange = {25,35};
    [SerializeField] private float currentGameTime = 0;
    [SerializeField] private float maxGameTime = 100;
    private int lives = 10;
    private int maxLives = 10;
    private int score = 0;

    void Start() {
        StartCoroutine(Countdown());
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
            if ( p.GetOrdered() == false ) {
                int x = UnityEngine.Random.Range(0,Orders.possibleOrders.Length);
                p.OrderUp( x , NextDistribution() );
            }
        }
    }

    public float NextDistribution() {
        return UnityEngine.Random.Range(timeRange[0],timeRange[1]);
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
        Globals.AddPoints( points );
    }

    public void Damage() {
        lives--;
        texts[0].SetText( lives.ToString() + " / " + maxLives );
        if ( lives == 0 ) {
            SceneManager.LoadScene("EndScene");
        }
    }

    IEnumerator Countdown() {
        yield return new WaitForSeconds( maxGameTime );
        Globals.Win();
        SceneManager.LoadScene("EndScene");
    }

}
