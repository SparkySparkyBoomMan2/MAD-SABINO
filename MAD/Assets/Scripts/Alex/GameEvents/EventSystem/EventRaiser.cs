using UnityEngine;

/* 
    Code inspired heavily from Stephen McVicker's work
    https://github.com/StephenMcVicker/Unity-ScriptableObjects-Game-Events-
*/

public class EventRaiser : MonoBehaviour
{

    public GameEvent eventToRaise;

    public void RaiseEvent()
    {
        if (eventToRaise == null)
        {
            Debug.Log("Event was not set for Event Raiser on GameObject named:" + gameObject.name);
            return;
        }

        eventToRaise.Raise();
    }
}
