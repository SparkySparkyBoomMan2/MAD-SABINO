using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        // Debug.Log("Name is:[" + col.name + "]");
        if(col.tag == "UserHand")
        {
            Debug.Log("[" + col.name + "] is interacting with the start sphere");
        }
    }
}