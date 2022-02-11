using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameEvent goalEvent;
    void OnTriggerEnter(Collider col)
    {
        // Debug.Log("Name is:[" + col.name + "]");
        if(col.tag == "UserHand")
        {
            goalEvent?.Raise();
            Debug.Log("[" + col.name + "] is touching the goal sphere!");
        }
    }
}
