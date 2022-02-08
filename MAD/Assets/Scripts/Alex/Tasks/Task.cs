using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName="Task", fileName ="New Task")]
public class Task : ScriptableObject
{
    public string taskName;
    public TaskConfig taskConfig;
    private event Action<string> taskEvent = TaskSystem.LoadSceneEvent;

    public void invokeTaskEvent()
    {
        taskEvent?.Invoke(taskName);
    }
}
