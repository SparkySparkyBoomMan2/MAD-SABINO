using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
//using SubjectNerd.Utilities;

/* 
    Code inspired heavily from Stephen McVicker's work
    https://github.com/StephenMcVicker/Unity-ScriptableObjects-Game-Events-
*/
public class EventListener : MonoBehaviour
{
    //[Reorderable]
    public List<EventAndResponse> eventAndResponses = new List<EventAndResponse>();

    private void OnEnable()
    {

        if (eventAndResponses.Count >= 1)
        {
            foreach (EventAndResponse eAndR in eventAndResponses)
            {
                eAndR.gameEvent.Register(this);
            }
        }


    }
    private void OnDisable()
    {
        if (eventAndResponses.Count >= 1)
        {
            foreach (EventAndResponse eAndR in eventAndResponses)
            {
                eAndR.gameEvent.Deregister(this);
            }
        }
    }

    [ContextMenu("Raise Events")]
    public void OnEventRaised(GameEvent passedEvent)
    {

        for (int i = eventAndResponses.Count - 1; i >= 0; i--)
        {
            // Check if the passed event is the correct one
            if (passedEvent == eventAndResponses[i].gameEvent)
            {
                // Uncomment the line below for debugging the event listens and other details
                //Debug.Log("Called Event named: " + eventAndResponses[i].name + " on GameObject: " + gameObject.name);


                eventAndResponses[i].EventRaised();
            }
        }

    }
}


[System.Serializable]
public class EventAndResponse
{
    public string name;
    public GameEvent gameEvent;
    public UnityEvent response;
    public ResponseWithString responseForSentString;
    public ResponseWithInt responseForSentInt;
    public ResponseWithFloat responseForSentFloat;
    public ResponseWithBool responseForSentBool;

    public ResponseWithVec3 responseForSentVec3;

    public void EventRaised()
    {
        // default/generic
        if (response.GetPersistentEventCount() >= 1) // always check if at least 1 object is listening for the event
        {
            response.Invoke();
        }

        // string
        if (responseForSentString.GetPersistentEventCount() >= 1)
        {
            responseForSentString.Invoke(gameEvent.sentString);
        }

        // int
        if (responseForSentInt.GetPersistentEventCount() >= 1)
        {
            responseForSentInt.Invoke(gameEvent.sentInt);
        }

        // float
        if (responseForSentFloat.GetPersistentEventCount() >= 1)
        {
            responseForSentFloat.Invoke(gameEvent.sentFloat);
        }

        // bool
        if (responseForSentBool.GetPersistentEventCount() >= 1)
        {
            responseForSentBool.Invoke(gameEvent.sentBool);
        }

        // vec3
        if (responseForSentVec3.GetPersistentEventCount() >= 1)
        {
            responseForSentVec3.Invoke(gameEvent.sentVec3);
        }

    }
}

[System.Serializable]
public class ResponseWithString : UnityEvent<string>
{
}

[System.Serializable]
public class ResponseWithInt : UnityEvent<int>
{
}

[System.Serializable]
public class ResponseWithFloat : UnityEvent<float>
{
}

[System.Serializable]
public class ResponseWithBool : UnityEvent<bool>
{
}

[System.Serializable]
public class ResponseWithVec3 : UnityEvent<Vector3>
{
}