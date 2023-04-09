using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookMove : MonoBehaviour
{
    private int foodValue = 0;
    private MeshRenderer meatMat;
    private string stillCooking = "y";

    // Start is called before the first frame update
    void Start()
    {
        meatMat= GetComponent<MeshRenderer>();
        StartCoroutine(cookTimer());
    }

    private void OnMouseDown()
    {
        GetComponent<Transform>().position = new Vector3(-.1f, .66f, GameFlow.plateZpos);
        GameFlow.plateValue[GameFlow.plateNum] += foodValue;
        stillCooking = "n";
    }

    IEnumerator cookTimer()
    {
        yield return new WaitForSeconds(7); //Cooks the patty for X seconds
        foodValue = 100000000; //Digit Value
        if (stillCooking == "y")
            meatMat.material.color = new Color(.36f, .25f, .2f); //Changes Patty Color
    }
}
