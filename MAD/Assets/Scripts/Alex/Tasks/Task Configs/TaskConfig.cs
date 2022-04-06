using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class scriptable object to provide variables and functions which all task configurations will need access to
// public abstract class TaskConfig : ScriptableObject
// {
//     // Boolean value to select use of the "table" or not
//     public bool useTable;

//     // Number of times to repeat the task
//     public int repeatNumber;

//     // Set the values back to their empty/zero value
//     public virtual void reset()
//     {
//         useTable = true;
//         repeatNumber = 0;
//     }

//     // To be called when repeating a task
//     // Decrements the number of times to repeat by -1
//     public void decrementRepeat()
//     {
//         if(repeatNumber > 0)
//         {
//             repeatNumber--;
//         }
//     }

//     // Print out the state of this configuration
//     public virtual void Print()
//     {
//         Debug.Log("##### Configuration ######");
//         Debug.Log(" - useTable: " + useTable);
//         Debug.Log(" - repeatNumber: " + repeatNumber);
//     }
// }

[CreateAssetMenu(menuName="Task Configuration", fileName ="New Task Config")]
public class TaskConfig : ScriptableObject
{
        public Config conf = null;
}

public class Config {
    // Boolean value to select use of the "table" or not
    public bool useTable;

    // Number of times to repeat the task
    public int repeatNumber;

    // Set the values back to their empty/zero value
    public virtual void reset()
    {
        useTable = true;
        repeatNumber = 0;
    }

    // To be called when repeating a task
    // Decrements the number of times to repeat by -1
    public void decrementRepeat()
    {
        if(repeatNumber > 0)
        {
            repeatNumber--;
        }
    }

    // Print out the state of this configuration
    public virtual void Print()
    {
        Debug.Log("##### Configuration ######");
        Debug.Log(" - useTable: " + useTable);
        Debug.Log(" - repeatNumber: " + repeatNumber);
    }
}

public class PointToPointConfig : Config {
    // (x,y,z) position offset coordiantes for the start, goal, and home positions
    public Vector3 goalPosition;
    public Vector3 startPosition;
    public Vector3 homePosition;

    // Overriding the base reset function to also set the new values to their "empty" value
    public override void reset()
    {
        base.reset();
        goalPosition  = new Vector3(0f,0f,0f);
        startPosition = new Vector3(0f,0f,0f); 
        homePosition  = new Vector3(0f,0f,0f); 
    }

    public override void Print()
    {
        base.Print();
        Debug.Log(" - home: " + homePosition);
        Debug.Log(" - start: " + startPosition);
        Debug.Log(" - goal: " + goalPosition);
    }
} 