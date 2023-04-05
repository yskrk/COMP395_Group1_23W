using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServePlate : MonoBehaviour
{ 
    private void OnMouseDown()
    {
        if(GameFlow.orderValue == GameFlow.plateValue)
        {
            Debug.Log("correct");
        } else
        {
            Debug.Log("incorrect");
        }
    }
}
