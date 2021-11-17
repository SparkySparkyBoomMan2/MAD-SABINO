using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table_Boundary : MonoBehaviour
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
        if(col.tag == "Item")
        {
            Debug.Log("Item has went off the table: " + col.tag);
        }
    }
}
