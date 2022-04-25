using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    // Inspector-assigned event to be invoked when the goal is "reached"
    public GameEvent homeEvent;
    public GameEvent homeReset;
    void OnTriggerEnter(Collider col)
    {
        // Debug.Log("Name is:[" + col.name + "]");
        if(col.tag == "UserHand")
        {
            homeEvent?.Raise();
            //Debug.Log("[" + col.name + "] is touching the home sphere!");
        }
    }

    // void OnTriggerExit(Collider col)
    // {
    //     if(col.tag == "UserHand")
    //     {
    //         homeReset?.Raise();
    //         // Debug.Log("[" + col.name + "] is leaving the goal sphere!");
    //     }
    // }
}
