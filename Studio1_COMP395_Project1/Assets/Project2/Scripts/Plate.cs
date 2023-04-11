using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class Plate : MonoBehaviour
{
    public Image image;
    [SerializeField] public Orders order;
    private float value = 1;
    private int cursor = 0;
    private List<Tuple<int,FoodValues>> onPlate;
    public float maxTime = 60;
    public float currentTime = 0;
    public bool ordered = false;
    public GameFlow gf;
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
        yield return new WaitForSeconds( maxTime/2 );
        image.color = new Color( 1 , 1 , 0 , 0.4f );
        yield return new WaitForSeconds( maxTime/4 );
        image.color = new Color( 1 , 0 , 0 , 0.4f );
        yield return new WaitForSeconds( maxTime/4 );
        Die();
    }

    public void OrderUp( int x ) {
        order = new Orders( x );
        ordered = true;
        cursor = 0;
        StartCoroutine("ChangeTimer");
    }

    public void Recieve( GameObject obj , FoodValues top ) {
        
        Instantiate(obj, new Vector3(-0.1f, 1f, gf.plateZpos), Quaternion.identity, transform);
        if ( top != order.recipe[cursor].Item2 ) {
            value -= 1 / (float)order.getMaxValue();
        }
        else {
            Debug.Log(cursor >= order.recipe.Count );
            int oneLess = order.recipe[cursor].Item1 - 1;
            order.recipe[cursor] = new Tuple<int,FoodValues>( oneLess ,order.recipe[cursor].Item2);
            if ( oneLess == 0 ) cursor++;
            Debug.Log(cursor >= order.recipe.Count );
            if ( cursor >= order.recipe.Count ) { Serve(); }
        }
    }

    private void Serve() {
        if ( value < 0.1 ) value = 0.1f;
        float score = order.getMaxValue() * value * 100;
        Reset();
        foreach ( Transform t in transform.GetComponentInChildren<Transform>() ) {
            if (t.CompareTag("GameController")){}
            else Destroy(t.gameObject);
        }
    }

    private void Die() {
        Reset();
    }

    private void Reset() {
        StopAllCoroutines();
        currentTime = 0;
        ordered = false;
        cursor = 0;
    }
}
