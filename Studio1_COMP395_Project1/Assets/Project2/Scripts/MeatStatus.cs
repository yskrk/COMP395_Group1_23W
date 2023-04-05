using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatStatus : MonoBehaviour
{
    public Transform cloneObj;

    private void OnMouseDown()
    {
        if(gameObject.name == "Cutlet")
            Instantiate(cloneObj, new Vector3(-0.175f, .1f, 2.6f), cloneObj.rotation);
    }
}
