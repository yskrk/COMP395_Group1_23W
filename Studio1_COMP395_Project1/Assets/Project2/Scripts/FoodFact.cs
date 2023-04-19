using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFact : MonoBehaviour
{
    public string message;

    private void OnMouseEnter()
    {
        FoodFactManager._instance.SetAndShowFoodFact(message);
    }

    private void OnMouseExit()
    {
        FoodFactManager._instance.HideFoodFact();

    }
}
