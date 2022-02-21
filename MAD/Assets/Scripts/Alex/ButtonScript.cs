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
        // Get a reference to this object's button component
        Button thisButton = GetComponent<Button>();

        // Set the text of the button to the name of the task
        thisButton.GetComponentInChildren<TextMeshProUGUI>().SetText(task.taskName, true);
        
        // Set the onclick function of the button to load the task scene
        thisButton.onClick.AddListener(() => task.invokeTaskEvent());
    }
}
