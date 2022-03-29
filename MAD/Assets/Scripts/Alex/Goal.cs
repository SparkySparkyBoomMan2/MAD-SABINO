using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Inspector-assigned event to be invoked when the goal is "reached"
    public GameEvent goalEvent, goalReset;//, moveEvent;

    void OnTriggerEnter(Collider col)
    {
        // Debug.Log("Name is:[" + col.name + "]");
        if(col.tag == "UserHand")
        {
            goalEvent?.Raise();
            Debug.Log("[" + col.name + "] is touching the goal sphere!");
        }
    }

    // public void MoveGoal(float x, float y, float z)
    // {
    //     Vector3 offset = new Vector3(x, y, z);
    //     gameObject.transform.Translate(offset);
    // }

    void OnTriggerExit(Collider col)
    {
        if(col.tag == "UserHand")
        {
            goalReset?.Raise();
            // Debug.Log("[" + col.name + "] is leaving the goal sphere!");
        }
    }
}
