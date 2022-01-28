using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    // Defined in the inspector
    public string taskSystemTag;

    // Not defined in inspector
    void Start()
    {
        // Get reference to TaskSystem Class and the button compontent of this button object
        TaskSystem taskSystem = GameObject.FindWithTag("TaskSystem").GetComponent<TaskSystem>();
        Button button = GetComponent<Button>();

        // Get the text (name of the scene pointing to) From the button's first child, Text,
        string buttonText = button.GetComponentInChildren<Text>().text;

        // If either lookup(s) fial, then return and log error message
        if(taskSystem == null || button == null || buttonText == null)
        {
            Debug.Log("Task System ERROR: button.onclick() has null component(s)");
            return;
        }

        // Add the Task System Class --> loadTask() function on click of the button
        // - Uses lambada functions
        // - https://forum.unity.com/threads/why-wont-onclick-addlistener-accept-a-field.357791/
        button.onClick.AddListener(() => taskSystem.LoadTask(buttonText));
    }
}
