using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class scriptable object to provide variables and functions which all task configurations will need access to
public abstract class TaskConfig : ScriptableObject
{
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

