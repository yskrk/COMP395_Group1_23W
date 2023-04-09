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
            Instantiate(cloneObj, new Vector3(-0.1f, .10f, GameFlow.plateZpos), cloneObj.rotation);

        if (gameObject.name == "topBun")
            Instantiate(cloneObj, new Vector3(-.1f, .60f, GameFlow.plateZpos), cloneObj.rotation);

        if (gameObject.name == "Cheese")
            Instantiate(cloneObj, new Vector3(-.1f, .62f, GameFlow.plateZpos), cloneObj.rotation);

        if (gameObject.name == "Bacon")
        {
            Instantiate(cloneObj, new Vector3(0, .62f, GameFlow.plateZpos), cloneObj.rotation);
            Instantiate(cloneObj, new Vector3(-.2f, .62f, GameFlow.plateZpos), cloneObj.rotation);
        }

        if (gameObject.name == "Mushroom")
        {
            Instantiate(cloneObj, new Vector3(0, .62f, GameFlow.plateZpos), cloneObj.rotation);
            Instantiate(cloneObj, new Vector3(-.2f, .62f, GameFlow.plateZpos), cloneObj.rotation);
        }

        if (gameObject.name == "Tomato")
        {
            Instantiate(cloneObj, new Vector3(-.1f, .62f, GameFlow.plateZpos), cloneObj.rotation);
        }

        if (gameObject.name == "Lettuce")
        {
            Instantiate(cloneObj, new Vector3(-.1f, .62f, GameFlow.plateZpos), cloneObj.rotation);
        }

        if (gameObject.name == "Onion")
        {
            Instantiate(cloneObj, new Vector3(-.1f, .62f, GameFlow.plateZpos), cloneObj.rotation);
        }

        if (gameObject.name == "Cheese2")
        {
            Instantiate(cloneObj, new Vector3(-.1f, .62f, GameFlow.plateZpos), cloneObj.rotation);
        }

        GameFlow.plateValue[GameFlow.plateNum] += foodValue;
        Debug.Log("Plate Value: " + GameFlow.plateValue[GameFlow.plateNum] + " Order Value: " + GameFlow.orderValue[GameFlow.plateNum]);

    }
}
