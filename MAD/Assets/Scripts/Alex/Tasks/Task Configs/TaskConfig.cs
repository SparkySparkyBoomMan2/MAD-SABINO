using UnityEngine;

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
    // public Vector3 goalPosition;
    // public Vector3 startPosition;
    // public Vector3 homePosition;
    public float goalX, goalY, goalZ;
    public float startX, startY, startZ;
    public float homeX, homeY, homeZ;

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
    }

    public override void Print()
    {
        base.Print();
        Debug.Log(" - home: " + homeX + ' ' + homeY + ' ' + homeZ);
        Debug.Log(" - start: " + startX + ' ' + startY + ' ' + startZ);
        Debug.Log(" - goal: " + goalX + ' ' + goalY + ' ' + goalZ);
    }
} 