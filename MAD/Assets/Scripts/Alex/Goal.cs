using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Inspector-assigned event to be invoked when the goal is "reached"
    public GameEvent goalEvent;
    public GameEvent goalReset;
    void OnTriggerEnter(Collider col)
    {
        // Debug.Log("Name is:[" + col.name + "]");
        if(col.tag == "UserHand")
        {
            goalEvent?.Raise();
            Debug.Log("[" + col.name + "] is touching the goal sphere!");
        }
    }

    // void OnTriggerExit(Collider col)
    // {
    //     if(col.tag == "UserHand")
    //     {
    //         goalReset?.Raise();
    //         // Debug.Log("[" + col.name + "] is leaving the goal sphere!");
    //     }
    // }
}
