using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

// Speicalized class for holding data and function references for tasks
[CreateAssetMenu(menuName="Task", fileName ="New Task")]
public class Task : ScriptableObject
{
    // Name of the task (this will be the name of the scene to be loaded too)
    public string taskName;

    // Specialied class for holding data specific to the configuration for this task
    public TaskConfig taskConfig;

    // Event that this task defines to be triggered
    // * We default the method LoadSceneEvent fromthe TaskSystem class
    // * This static method broadcasts the onLoadSceneEvent on the task system
    // * Also passes in the taskName as the scene to load
    private event Action<string> taskEvent = TaskSystem.LoadSceneEvent;

    // Invoke the subscribed task event, passing in the taskName as parameter
    public void invokeTaskEvent()
    {
        taskEvent?.Invoke(taskName);
    }
}
