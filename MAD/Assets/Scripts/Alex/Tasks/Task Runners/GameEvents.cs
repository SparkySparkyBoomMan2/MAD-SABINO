using System.Collections.Generic;
using UnityEngine;

public class GameEvents
{
    private List<GameEvent> events; 
    public GameEvents(string path)
    {
        events = new List<GameEvent>();
        events.AddRange(Resources.LoadAll<GameEvent>(path));
    }

    public void Clear()
    {
        events.Clear();
    }

    public bool Empty()
    {
        if(events.Count == 0)
            return true;

        return false;
    }

    public void Print()
    {
        foreach (GameEvent ge in events)
        {
            Debug.Log("\"" + ge + "\"");
        }

    }

    private string RemoveEnd(string name)
    {
        int idx = name.LastIndexOf(" (GameEvent)");
        return name.Remove(idx);
    }

    public GameEvent Get(string name)
    {
        GameEvent ge = events.Find(
            x => RemoveEnd(x.ToString()) == name
        );

        if(ge == null) 
            Debug.LogErrorFormat("GameEvents: name \"" + name 
                + "\" was not found in the list of events, the result is null.");

        return ge;
    }

    public GameEvent this[string s]
    {
        get { return Get(s); }
    }
}
