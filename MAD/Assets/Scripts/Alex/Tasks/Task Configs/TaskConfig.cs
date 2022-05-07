using UnityEngine;

// Why ScriptableObject?
/* Unite Austin 2017 - Game Architecture with Scriptable Objects
 * https://www.youtube.com/watch?v=6vmRwLYWNRo 
 *
 * Unite 2016 - Overthrowing the MonoBehaviour Tyranny in a Glorious Scriptable Object Revolution
 * https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=1964s
 */
 
 // This is the scriptable object  which can be created
[CreateAssetMenu(menuName="Task Configuration", fileName ="New Task Config")]
public class TaskConfig : ScriptableObject
{
        // This is a generic reference to some Configuration.
        // Childern of the Config class (like PointToPointConfig) can also be stored in this variable.
        // This is what allows multiple configurations to be stored inside one scriptableobject.
        public Config conf = null;
}

public class Config {
    // Boolean value to select use of the "table" or not
    public bool useTable;

    // Number of times to run the task
    public int runs;

    // Set the values back to their empty/zero value
    public virtual void reset()
    {
        useTable = true;
        runs = 1;
    }

    // Print out the state of this configuration
    public virtual void Print()
    {
        Debug.Log("##### Configuration ######");
        Debug.Log(" - useTable: " + useTable);
        Debug.Log(" - runs: " + runs);
    }
}

public class PointToPointConfig : Config {
    // (x,y,z) position offset coordiantes for the start, goal, and home positions
    // public Vector3 goalPosition;
    // public Vector3 startPosition;
    // public Vector3 homePosition;
    public float goalX, goalY, goalZ;
    public float startX, startY, startZ;
    public float homeX, homeY, homeZ;
    
    /* We have access to runs through inheritance */
    // public int runs; // MIGUEL VILLANUEVA // Alex Peña 4/25/22
    // Indicates to use the home position when true.
    // - Only use the start and goal positions when false
    public bool useHome;

    public PointToPointConfig()
    {   
        reset();
    }

    // Overriding the base reset function to also set the new values to their "empty" value
    public override void reset()
    {
        base.reset();
        goalX = goalY = goalZ = 0;
        homeX = homeY = homeZ = 0;
        startX = startY = startZ = 0;
        useHome = true;
    }

    public override void Print()
    {
        base.Print();
        Debug.Log(" - home: " + homeX + ' ' + homeY + ' ' + homeZ);
        Debug.Log(" - start: " + startX + ' ' + startY + ' ' + startZ);
        Debug.Log(" - goal: " + goalX + ' ' + goalY + ' ' + goalZ);
        Debug.Log(" - useHome: " + useHome);
    }
} 