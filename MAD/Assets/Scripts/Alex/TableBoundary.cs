using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBoundary : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Item")
        {
            Debug.Log("Item has went off the table: " + col.tag);
        }
    }
}
