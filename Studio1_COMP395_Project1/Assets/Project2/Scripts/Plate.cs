using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

[Serializable]
public class Plate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private Image image;
    [SerializeField] private Orders order;
    private float value = 1.0f;
    private int cursor = 0;
    [SerializeField] private float maxTime = 30;
    [SerializeField] private float currentTime = 0;
    private bool ordered = false;
    private GameFlow gf;
    private float yValue = 0.5f;
    [SerializeField] private GameObject[] stars;
    // Start is called before the first frame update
    void Start()
    {
        gf = FindObjectOfType<GameFlow>();
        OrderUp( 0 );
    }

    // Update is called once per frame
    void Update()
    {
        if ( ordered ) currentTime += Time.deltaTime;
        image.fillAmount = Mathf.Clamp( currentTime / maxTime , 0 , 1 );
    }

    IEnumerator ChangeTimer() {
        image.color = new Color( 1 , 1 , 1 , 0.4f );
        yield return new WaitForSeconds( maxTime/2 );
        image.color = new Color( 1 , 1 , 0 , 0.4f );
        yield return new WaitForSeconds( maxTime/4 );
        image.color = new Color( 1 , 0 , 0 , 0.4f );
        yield return new WaitForSeconds( maxTime/4 );
        Die();
    }

    public void OrderUp( int x ) {
        maxTime = 60;
        order = new Orders( x );
        string recipeText = "Recipe:\n1x Bottom Bun\n" + Orders.orderTexts[x] + "1x Top Bun";
        tmp.SetText( recipeText );
        ordered = true;
        cursor = 0;
        StartCoroutine("ChangeTimer");
    }

    public void OrderUp( int x , float newMaxTime ) {
        maxTime = newMaxTime;
        OrderUp( x );
    }

    public void Recieve( GameObject obj , FoodValues top ) {
        
        Instantiate(obj, new Vector3(-0.1f, yValue, transform.position.z ), Quaternion.identity, transform);
        yValue += 0.055f;
        if ( top != order.recipe[cursor].Item2 ) {
            Debug.Log(order.recipe[cursor].Item2);
            value -= 1 / (float)order.getMaxValue();
            if ( value < 0 ) Die();
        }
        else {
            int oneLess = order.recipe[cursor].Item1 - 1;
            order.recipe[cursor] = new Tuple<int,FoodValues>( oneLess ,order.recipe[cursor].Item2);
            if ( oneLess == 0 ) cursor++;
            if ( cursor >= order.recipe.Count ) { StartCoroutine(Serve()); }
        }
    }

    public IEnumerator Serve() {
        Globals.AddPlates();
        stars[0].SetActive( true );
        stars[1].SetActive( true );
        stars[2].SetActive( true );
        yield return new WaitForSeconds( 0.33f );
        stars[3].SetActive( true );
        if ( value >= 0.5f ) {
            yield return new WaitForSeconds( 0.33f );
            stars[4].SetActive( true );
        }
        if ( value >= 0.9f ) {
            yield return new WaitForSeconds( 0.33f );
            stars[5].SetActive( true );
        }
        yield return new WaitForSeconds( 1f );
        float score = order.getMaxValue() * value * 100;
        gf.Score( Mathf.RoundToInt(score) );

        foreach ( Transform t in transform.GetComponentInChildren<Transform>() ) {
            if (t.CompareTag("GameController")){}
            else Destroy(t.gameObject);
        }
        Reset();
    }

    private void Die() {
        gf.Damage();
        Globals.AddLoss();
        Reset();
    }

    private void Reset() {
        yValue = 0.5f;
        currentTime = 0;
        ordered = false;
        cursor = 0;
        value = 1.0f;
        foreach ( Transform t in transform.GetComponentInChildren<Transform>() ) {
            if (t.CompareTag("GameController")){}
            else Destroy(t.gameObject);
        }
        foreach ( GameObject go in stars ) {
            go.SetActive( false );
        }
        StopAllCoroutines();
    }

    public void Activate() {
        tmp.gameObject.SetActive(true);
    }

    public void Deactivate() {
        tmp.gameObject.SetActive(false);
    }

    public bool GetOrdered() {
        return ordered;
    }

}
