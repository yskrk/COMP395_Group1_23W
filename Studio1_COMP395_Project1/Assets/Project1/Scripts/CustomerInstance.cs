using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerInstance : MonoBehaviour
{
    public double serviceTime;
    public Transform target;
    public Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(0,7);
        foreach ( Transform child in transform ) {
            child.gameObject.GetComponent<Renderer>().material = materials[x];
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * Time.deltaTime;
    }
}
