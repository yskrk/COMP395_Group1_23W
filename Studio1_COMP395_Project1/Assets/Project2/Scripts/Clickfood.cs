using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickfood : MonoBehaviour
{
    public GameObject cloneObj;
    public FoodValues type;
    public GameFlow gf;

    private void OnMouseDown()
    {
        if (gf == null) {
            gf = FindObjectOfType<GameFlow>();
        }
        gf.PutOnPlate( cloneObj , type );
        
        // GameFlow.plateValue[GameFlow.plateNum] += foodValue;
        // Debug.Log("Plate Value: " + GameFlow.plateValue[GameFlow.plateNum] + " Order Value: " + GameFlow.orderValue[GameFlow.plateNum]);

    }
}
