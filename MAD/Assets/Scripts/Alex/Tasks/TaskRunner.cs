using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TaskRunner : MonoBehaviour
{
    // General TaskConfig scritable object that can be assigned any task config in the inspector
    public TaskConfig taskConfig;

    // Local copy of the specific task config that was assigned in the inspector
    private TaskConfig taskConfigCopy;

        /*
        Task runner should be able to have a list of events that we can add to it dynamically
        - list of events stored that we can add to or remove from dynamically
        - call/broadcast any one of them
        - subscribe a method to, or remove a method from them as well
    */ 
    // List of gameEvents for a specifc task
    public List<GameEvent> gameEventsPublic = new List<GameEvent>();

    private List<GameEvent> gameEvents = new List<GameEvent>();

    void Start()
    {
        // Copy the task configuration
        taskConfigCopy = Instantiate(taskConfig);

        // Copy the events in the public GameEvent list to a private one
        // (this way we can modify them without changing the S.O)
        gameEvents?.Clear();
        gameEvents.AddRange(gameEventsPublic);

        
        // TODO: Setup the objects in configuration
    }


    // TODO: Write main logic loop


    // Register/Add a new GameEvent to the list
    public void Register(GameEvent newEvent)
    {
        if(!gameEvents.Contains(newEvent))
        {
            gameEvents.Add(newEvent);
        }
    }

    // Deregister/Remove a current GameEvent from the list
    public void Deregister(GameEvent oldEvent)
    {
        if(gameEvents.Contains(oldEvent))
        {
            gameEvents.Remove(oldEvent);
        }
    }

    // Trigger a specifc gameEvent in the list
    public void TriggerEvent(GameEvent targetEvent)
    {
        if(gameEvents.Contains(targetEvent))
        {
            targetEvent.Raise();
        }
    }
}
