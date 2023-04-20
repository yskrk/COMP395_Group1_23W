using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickfood : MonoBehaviour
{
    [SerializeField] private GameObject cloneObj;
    [SerializeField] private FoodValues type;
    [SerializeField] private GameFlow gf;
    private bool cooked = false;
    private bool cooking = false;

    private void OnMouseDown()
    {
        if (gf == null) {
            gf = FindObjectOfType<GameFlow>();
        }
        if ( type == FoodValues.Patty && cooking == false && cooked == false ){
            gf.PutOnPan( cloneObj );
        }
        else if ( type == FoodValues.Patty && cooked == true ) {
            gf.PutOnPlate( gameObject , type );
            Destroy( gameObject );
        }
        else if ( type != FoodValues.Patty ) gf.PutOnPlate( cloneObj , type );
        
        // GameFlow.plateValue[GameFlow.plateNum] += foodValue;
        // Debug.Log("Plate Value: " + GameFlow.plateValue[GameFlow.plateNum] + " Order Value: " + GameFlow.orderValue[GameFlow.plateNum]);

    }

    public IEnumerator Cook() {
        cooking = true;
        yield return new WaitForSeconds(5);
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.material.color = new Color(.36f,.25f,.2f);
        cooked = true;
    }
}
