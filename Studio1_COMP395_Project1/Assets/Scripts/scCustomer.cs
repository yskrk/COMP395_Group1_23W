using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


public class scCustomer : MonoBehaviour
{

    public class Customer{
        public double interarrival;
        public double service;
        public int number;

        public Customer(int num,double inter,double serv) {
            number=num;
            interarrival=inter;
            service=serv;
        }
        }

public Customer[] newCustomer;
public TextAsset target;
int count=0;

Customer[] readTextFile(string file_path)
{
   newCustomer = new Customer[500];
   StreamReader inp_stm = new StreamReader(file_path);
   while(!inp_stm.EndOfStream)
   {
       string inp_ln = inp_stm.ReadLine( );
       string[] result = inp_ln.Split("	");
       //Debug.Log(result[0]+" "+result[1]+" "+result[2]);
       newCustomer[count] = new Customer(int.Parse(result[0]),double.Parse(result[1]),double.Parse(result[2]));
       Debug.Log("New Customer "+newCustomer[count].number+": ("+newCustomer[count].interarrival+","+newCustomer[count].service+")");
       count++;
   }
   inp_stm.Close( );  
   return newCustomer;
}

    // Start is called before the first frame update
    void Start()
    {
        readTextFile(AssetDatabase.GetAssetPath(target));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
