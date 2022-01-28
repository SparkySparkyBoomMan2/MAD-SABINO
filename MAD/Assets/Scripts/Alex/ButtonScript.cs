using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    // Tag which is set on the TaskSystem object; set in inspector
    public string taskSystemTag;

    void Start()
    {
        // Get reference to TaskSystem Class and the button compontent of this button object
        // - (taskSystem) This should always be present, as it is in "DontDestroyOnLoad"
        TaskSystem taskSystem = GameObject.FindWithTag("TaskSystem").GetComponent<TaskSystem>();
        Button button = GetComponent<Button>();

        // The child of this object SHOULD be a Text object
        // - access the "text" field of this Text object, and store it
        // - buttonText will correspond both to what the user sees, and what the scene is named
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
