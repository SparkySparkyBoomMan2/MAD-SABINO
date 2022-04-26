using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting : MonoBehaviour
{
    // Inspector-assigned event to be invoked when the goal is "reached"
    public GameEvent startEvent;
    public GameEvent startReset;
    void OnTriggerEnter(Collider col)
    {
        // Debug.Log("Name is:[" + col.name + "]");
        if(col.tag == "UserHand")
        {
            startEvent?.Raise();
            // Debug.Log("[" + col.name + "] is touching the start sphere!");
        }
    }

    // void OnTriggerExit(Collider col)
    // {
    //     if(col.tag == "UserHand")
    //     {
    //         startReset?.Raise();
    //         // Debug.Log("[" + col.name + "] is leaving the goal sphere!");
    //     }
    // }
}
