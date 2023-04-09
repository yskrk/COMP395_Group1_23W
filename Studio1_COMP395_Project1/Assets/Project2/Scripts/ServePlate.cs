using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServePlate : MonoBehaviour
{ 
    private void OnMouseDown()
    {
        if (GameFlow.orderValue[GameFlow.plateNum] == GameFlow.plateValue[GameFlow.plateNum])
        {
            Debug.Log("Correct. Time Left " + GameFlow.orderTimer[GameFlow.plateNum] + " sec");
        } else
        {
            Debug.Log("Incorrect. Time Left " + GameFlow.orderTimer[GameFlow.plateNum] + " sec");
        }
    }
}
