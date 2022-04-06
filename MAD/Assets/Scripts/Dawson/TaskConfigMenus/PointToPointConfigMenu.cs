using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointToPointConfigMenu : MonoBehaviour
{
    //NOTE: I wanted to wait for Alex to look at the code before adding the following line in, as well as the subsequent lines:
    public TaskConfig taskConfig;
    public Slider sliderUI;
    private Text textSliderValue;

    /// <summary>
    /// Changes the value of the slider and passes the information to the scriptable object.
    /// </summary>
    public void SliderChanged()
    {
        var pConf = taskConfig.conf as PointToPointConfig;
        if (pConf == null)
            return;
        
        switch (sliderUI.name)
        { 
            case "StartPosX":
                //pointToPointConfig.startPosition.x = sliderUI.value;
                // Debug.Log("Debug message:" + sliderUI.name + sliderUI.value);
                pConf.startX = sliderUI.value;
                // Debug.Log("Debug message pconf!: " + pConf.startX);
                break;

            case "StartPosY":
                //pointToPointConfig.startPosition.y = sliderUI.value;
                // Debug.Log("Debug message:" + sliderUI.name + sliderUI.value);
                pConf.startY = sliderUI.value;
                break;

            case "StartPosZ":
                //pointToPointConfig.startPosition.z = sliderUI.value;
                // Debug.Log("Debug message:" + sliderUI.name + sliderUI.value);
                pConf.startZ = sliderUI.value;
                break;

            case "GoalPosX":
                //pointToPointConfig.goalPosition.x = sliderUI.value;
                // Debug.Log("Debug message:" + sliderUI.name + sliderUI.value);
                pConf.goalX = sliderUI.value;
                break;
            
            case "GoalPosY":
                //pointToPointConfig.goalPosition.y = sliderUI.value;
                // Debug.Log("Debug message:" + sliderUI.name + sliderUI.value); ;
                pConf.goalY = sliderUI.value;
                break;

            case "GoalPosZ":
                //pointToPointConfig.goalPosition.z = sliderUI.value;
                // Debug.Log("Debug message:" + sliderUI.name + sliderUI.value); 
                pConf.goalZ = sliderUI.value;
                break;

            default:
                // Debug.Log("[ERROR] Error receiving slider data. Name: " + sliderUI.name);
                break;
        }

    }
    /// <summary>
    /// Gets the value from the slider to be displayed on the UI canvas.
    /// </summary>
    public void ShowSliderValue()
    {
        string sliderMessage = "Value: " + Math.Round(sliderUI.value, 2);
        textSliderValue.text = sliderMessage;
    }

    // Start is called before the first frame update
    void Start()
    {
        textSliderValue = GetComponent<Text>();
        // SliderChanged();
        // ShowSliderValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
