using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TaskRunner : MonoBehaviour
{
    // General TaskConfig scritable object that can be assigned any task config in the inspector
    public TaskConfig taskConfig;

    
    public virtual void Start() {}
    public virtual void Setup() {}
    public virtual void Run() {}

    public virtual void resetAll() {}

    protected IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
