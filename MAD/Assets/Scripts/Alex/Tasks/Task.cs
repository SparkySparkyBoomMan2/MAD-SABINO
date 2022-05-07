using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

// Why ScriptableObject?
/* Unite Austin 2017 - Game Architecture with Scriptable Objects
 * https://www.youtube.com/watch?v=6vmRwLYWNRo 
 *
 * Unite 2016 - Overthrowing the MonoBehaviour Tyranny in a Glorious Scriptable Object Revolution
 * https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=1964s
 */
// Speicalized class for holding data and function references for tasks
[CreateAssetMenu(menuName="Task", fileName ="New Task")]
public class Task : ScriptableObject
{
    // Name of the Task.
    // i.e., the name of the scene to load
    public string taskName;

    // Specialied class for holding config info
    // public TaskConfig taskConfig;

    // Event that this task defines to be triggered
    private event Action<string> _taskEvent;


    // Invoke the subscribed task event
    public void taskSceneLoad()
    {
        /*
         * _taskEvent is an event which allows us to point to a function to call.
         *
         * When this function is called, it will point _taskEvent to 
         * TaskSystem's LoadScene() method.
         *
         * Then, it will invoke the _taskEvent, which calls any function that "points" to it.
         *
         *
         */
        _taskEvent += TaskSystem.LoadSceneEvent; 
        _taskEvent?.Invoke(taskName);
        _taskEvent -= TaskSystem.LoadSceneEvent; 
    }

    // Invoke the subscribed task event
    public void taskConfigLoad()
    {
        /*
         * _taskEvent is an event which allows us to point to a function to call.
         *
         * When this function is called, it will point _taskEvent to 
         * TaskSystem's LoadScene() method.
         *
         * Then, it will invoke the _taskEvent, which calls any function that "points" to it.
         */
        _taskEvent += TaskSystem.LoadSceneEvent; 
        _taskEvent?.Invoke(taskName + "Config");
        _taskEvent -= TaskSystem.LoadSceneEvent; 
    }
}
