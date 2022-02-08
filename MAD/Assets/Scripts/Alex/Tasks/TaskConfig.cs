using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class TaskConfig : ScriptableObject
{
    public bool useTable;
    public int repeatNumber;

    public virtual void reset()
    {
        useTable = false;
        repeatNumber = 0;
    }

    public void decrementRepeat()
    {
        if(repeatNumber > 0)
        {
            repeatNumber--;
        }
    }
}

