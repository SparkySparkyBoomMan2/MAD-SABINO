using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    // Task object assigned in inspector
    public Task task;
    void Start()
    {
        // Get a reference to this object's Button component
        Button thisButton = GetComponent<Button>();

        // Set the text of the button to name specfied in the Task
        thisButton.GetComponentInChildren<TextMeshProUGUI>().SetText(task.taskName, true);
        
        // Set the onclick function of the button to load the task scene
        // thisButton.onClick.AddListener(() => task.taskScene());

        // Set the onclick function of the button to load the configuration scene
        thisButton.onClick.AddListener(() => task.taskConfigLoad());
    }
}
