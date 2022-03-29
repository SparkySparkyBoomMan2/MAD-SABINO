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
    private event Action<string, TaskConfig> taskEvent; 

    // Invoke the subscribed task event, passing in the taskName as parameter
    public void invokeTaskEvent()
    {
        taskEvent += TaskSystem.LoadSceneEvent; // The method LoadSceneEvent is subscribed to the taskEvent event. This creates an extra dependency: Task -> TaskSystem. Just something to keep in mind
        taskEvent?.Invoke(taskName, taskConfig);            // If the event has at least one subscrier, then invoke the event with the taskName
        taskEvent -= TaskSystem.LoadSceneEvent; // Unsubscribe the method ...LoadSceneEvent from the event taskEvent
    }
}
