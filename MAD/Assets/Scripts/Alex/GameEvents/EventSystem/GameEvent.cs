using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
    Code from Stephen McVicker's work
    https://github.com/StephenMcVicker/Unity-ScriptableObjects-Game-Events-
*/

[CreateAssetMenu(menuName = "Game Event")]
public class GameEvent : ScriptableObject
{

    public string sentString;
    public int sentInt;
    public float sentFloat;
    public bool sentBool;

    public Vector3 sentVec3;

    // List of event listerners, i.e., action to be taken when the game event is raised
    private List<EventListener> eventListeners = new List<EventListener>();

    // Raise this game event, subsequently invokinng/raising all of the listeners
    public void Raise()
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised(this);
        }
    }

    // Register/add a new listener
    public void Register(EventListener passedEvent)
    {

        if (!eventListeners.Contains(passedEvent))
        {
            eventListeners.Add(passedEvent);
        }

    }

    // Deregister/remove an existing listener
    public void Deregister(EventListener passedEvent)
    {

        if (eventListeners.Contains(passedEvent))
        {
            eventListeners.Remove(passedEvent);
        }

    }

}