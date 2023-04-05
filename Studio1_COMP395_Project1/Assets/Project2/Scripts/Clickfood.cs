using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickfood : MonoBehaviour
{
    public Transform cloneObj;
    public int foodValue;

    private void OnMouseDown()
    {
        if (gameObject.name == "bottomBun")
            Instantiate(cloneObj, new Vector3(-0.1f, .10f, -1f), cloneObj.rotation);

        if (gameObject.name == "topBun")
            Instantiate(cloneObj, new Vector3(-.1f, .60f, -1f), cloneObj.rotation);

        if (gameObject.name == "Cheese")
            Instantiate(cloneObj, new Vector3(-.1f, .62f, -1f), cloneObj.rotation);

        if (gameObject.name == "Bacon")
        {
            Instantiate(cloneObj, new Vector3(0, .62f, -1f), cloneObj.rotation);
            Instantiate(cloneObj, new Vector3(-.2f, .62f, -1f), cloneObj.rotation);
        }

        GameFlow.plateValue += foodValue;
        Debug.Log("Plate Value: " + GameFlow.plateValue + " Order Value: " + GameFlow.orderValue);

    }
}
