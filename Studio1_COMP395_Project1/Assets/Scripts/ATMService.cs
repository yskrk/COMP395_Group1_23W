using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMService : MonoBehaviour
{
    public Transform serviceLocation;
    public Transform endLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        Service( other );
    }

    IEnumerator Service( Collision other ) {
        UnityEngine.AI.NavMeshAgent agent = other.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        yield return new WaitForSeconds( (float) other.gameObject.GetComponent<CustomerInstance>().serviceTime);
        agent.SetDestination(endLocation.position);
    }
}
