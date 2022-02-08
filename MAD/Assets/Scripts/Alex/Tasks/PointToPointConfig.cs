using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Specific configuration for the Point to Point task
[CreateAssetMenu(menuName="Task Configuration/ Point to Point", fileName ="New Task Config")]
public class PointToPointConfig : TaskConfig
{
    // (x,y,z) position coordiantes for the home, start, and goal locations
    public Vector3 homePosition;
    public Vector3 goalPosition;
    public Vector3 startPosition;

    // Overriding the base reset function to also set the new values to their "empty" value
    public override void reset()
    {
        base.reset();
        homePosition  = new Vector3(0,0,0);
        goalPosition  = new Vector3(0,0,0);
        startPosition = new Vector3(0,0,0); 
    }
}
