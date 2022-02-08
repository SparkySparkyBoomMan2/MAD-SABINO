using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Task Configuration/ Point to Point", fileName ="New Task Config")]
public class PointToPointConfig : TaskConfig
{
    public Vector3 homePosition;
    public Vector3 goalPosition;
    public Vector3 startPosition;

    public override void reset()
    {
        base.reset();
        homePosition  = new Vector3(0,0,0);
        goalPosition  = new Vector3(0,0,0);
        startPosition = new Vector3(0,0,0); 
    }
}
