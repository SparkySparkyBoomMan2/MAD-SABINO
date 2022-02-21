using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointToPointConfigMenu : MonoBehaviour
{
    //NOTE: I wanted to wait for Alex to look at the code before adding the following line in, as well as the subsequent lines:
    //PointToPointConfig pointToPointConfig;
    public Slider sliderUI;
    private Text textSliderValue;

    /// <summary>
    /// Changes the value of the slider and passes the information to the scriptable object.
    /// </summary>
    public void SliderChanged()
    {
        switch (sliderUI.name)
        { 
            case "StartPosX":
                //pointToPointConfig.startPosition.x = sliderUI.value;
                Debug.Log("Debug message:" + sliderUI.name + sliderUI.value);
                break;

            case "StartPosY":
                //pointToPointConfig.startPosition.y = sliderUI.value;
                Debug.Log("Debug message:" + sliderUI.name + sliderUI.value);
                break;

            case "StartPosZ":
                //pointToPointConfig.startPosition.z = sliderUI.value;
                Debug.Log("Debug message:" + sliderUI.name + sliderUI.value);
                break;

            case "GoalPosX":
                //pointToPointConfig.goalPosition.x = sliderUI.value;
                Debug.Log("Debug message:" + sliderUI.name + sliderUI.value);
                break;
            
            case "GoalPosY":
                //pointToPointConfig.goalPosition.y = sliderUI.value;
                Debug.Log("Debug message:" + sliderUI.name + sliderUI.value); ;
                break;

            case "GoalPosZ":
                //pointToPointConfig.goalPosition.z = sliderUI.value;
                Debug.Log("Debug message:" + sliderUI.name + sliderUI.value); 
                break;

            default:
                Debug.Log("[ERROR] Error receiving slider data. Name: " + sliderUI.name);
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
        SliderChanged();
        ShowSliderValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
