using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    // Task object assigned in inspector
    public Task task;
    void Start()
    {
        // Get a reference to this object's button component
        Button thisButton = GetComponent<Button>();

        // Set the text to the name of the task
        thisButton.GetComponentInChildren<Text>().text = task.taskName;
        
        // Set the onclick function to load the task scene
        thisButton.onClick.AddListener(() => task.invokeTaskEvent());
    }
}
