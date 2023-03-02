using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMService : MonoBehaviour
{
    public Transform serviceLocation;
    public Transform endLocation;
    public GameObject currentCustomer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( currentCustomer != null && currentCustomer.transform.position.x < 0 ) {
            currentCustomer.transform.position = new Vector3 ( 0 , currentCustomer.transform.position.y , currentCustomer.transform.position.z );
        }
    }

    private void OnTriggerEnter(Collider other) {
        currentCustomer = other.gameObject;
        StartCoroutine(Service());
    }

    IEnumerator Service() {
        if ( currentCustomer != null ) {
            UnityEngine.AI.NavMeshAgent agent = currentCustomer.GetComponent<UnityEngine.AI.NavMeshAgent>();
            CustomerInstance ci = currentCustomer.GetComponent<CustomerInstance>();
            agent.isStopped = true;
            yield return new WaitForSeconds((float) ci.serviceTime);
            ci.target = endLocation;
            agent.isStopped = false;
            agent.SetDestination(ci.target.position);
            currentCustomer = null;
        }
        
    }
}
