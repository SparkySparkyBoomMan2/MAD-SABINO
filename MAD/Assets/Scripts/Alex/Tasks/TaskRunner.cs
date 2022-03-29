using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TaskRunner : MonoBehaviour
{
    // General TaskConfig scritable object that can be assigned any task config in the inspector
    public TaskConfig taskConfig;

    public PointToPointConfig taskConfigCopy;

    public GameEvent moveGoal, moveStart, moveHome;

    public GameEvent 
        goToGoal, goToStart, goToHome, 
        goalReached, startReached, homeReached,
        resetGoal, resetStart, resetHome;

    // Local copy of the specific task config that was assigned in the inspector
    // private TaskConfig taskConfigCopy;

        /*
        Task runner should be able to have a list of events that we can add to it dynamically
        - list of events stored that we can add to or remove from dynamically
        - call/broadcast any one of them
        - subscribe a method to, or remove a method from them as well
    */ 
    // List of gameEvents for a specifc task
    // public List<GameEvent> gameEventsPublic = new List<GameEvent>();

    // private List<GameEvent> gameEvents = new List<GameEvent>();
    private event Action reloadEvent;

    void Start()
    {
        // Copy the task configuration
        taskConfigCopy = Instantiate(taskConfig) as PointToPointConfig;
        //taskConfigCopy.startPosition = new Vector3(0.0f, 0.5f, 0.0f);
        //taskConfigCopy.Print();

        // Copy the events in the public GameEvent list to a private one
        // (this way we can modify them without changing the S.O)
        // gameEvents?.Clear();
        // gameEvents.AddRange(gameEventsPublic);

        
        // TODO: Setup the objects in configuration
        Setup(taskConfigCopy);
        Run();
    }

    void Update()
    {

    }

    public void Setup(PointToPointConfig pConf)
    {
        Vector3 goalPos = pConf.goalPosition;
        Vector3 startPos = pConf.startPosition;
        Vector3 homePos = pConf.homePosition;

        moveGoal.sentVec3 = new Vector3(goalPos.x, goalPos.y, goalPos.z);
        moveGoal.Raise();

        moveStart.sentVec3 = new Vector3(startPos.x, startPos.y, startPos.z);
        moveStart.Raise();

        moveHome.sentVec3 = new Vector3(homePos.x, homePos.y, homePos.z);
        moveHome.Raise();
    }
     
    public void Run()
    {
        resetAll();

        goToHome.Raise();
        // The event listener on TaskRunner takes care of the rest
        // each iteration/loop will come back to here!
    }

    private void resetAll()
    {
        resetGoal.Raise();
        resetStart.Raise();
        resetHome.Raise();
    }

    public void ReloadScene()
    {
        if(taskConfigCopy.repeatNumber > 0) {
            taskConfigCopy.decrementRepeat();
            reloadEvent += TaskSystem.ReloadEvent;
            reloadEvent?.Invoke();
            reloadEvent -= TaskSystem.ReloadEvent;
        }
    }


    // TODO: Write main logic loop


    // // Register/Add a new GameEvent to the list
    // public void Register(GameEvent newEvent)
    // {
    //     if(!gameEvents.Contains(newEvent))
    //     {
    //         gameEvents.Add(newEvent);
    //     }
    // }

    // // Deregister/Remove a current GameEvent from the list
    // public void Deregister(GameEvent oldEvent)
    // {
    //     if(gameEvents.Contains(oldEvent))
    //     {
    //         gameEvents.Remove(oldEvent);
    //     }
    // }

    // // Trigger a specifc gameEvent in the list
    // public void TriggerEvent(GameEvent targetEvent)
    // {
    //     if(gameEvents.Contains(targetEvent))
    //     {
    //         targetEvent.Raise();
    //     }
    // }
}
