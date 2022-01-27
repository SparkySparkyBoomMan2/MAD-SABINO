using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TaskSystem : Singleton
{
    void Start()
    {
        getAllScenes(sceneListInBuild);
    }

    // This will need to be attatched to the main hierarchy, and be the DONT DESTROY ON LOAD
    public string taskName = ""; // Name of the basic task
    public int repeatNumber = 0; // Optional number of times to repeat the task

    public int time;
    public bool useTable = true;

    public string sceneName; // Name of the scene/task to load

    // These will all be positions, relative to their original locations
    // - i.e., if we have a table, then the goal will start in the middle of the table, and changes to the vector3 will move it accordingly from that starting position
    public Vector3 goalPosition;
    public Vector3 homePosition;
    public Vector3 startPosition;

    // Private list to hold all scnene names
    private static List<string> sceneListInBuild = new List<string>();

    // Inspired heavily from...
    // http://answers.unity.com/answers/1394340/view.html
    private void getAllScenes(List<string> sceneList) 
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        for(int i = 0; i < sceneCount; i++) 
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            int slashIndex = scenePath.LastIndexOf("/");
            sceneListInBuild.Add(scenePath.Substring(slashIndex+1, scenePath.LastIndexOf(".") - slashIndex-1));
        }
    }

    // Loads the selected task and unloads the current scene
    // MAKE SURE WE ADD SCENES TO THE BUILD SETTIGNS!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // OR THIS WONT WORK
    public void loadTask(string targetScene="")
    {
        foreach (var sName in sceneListInBuild)
        {
            Debug.Log(sName);
        }
        if (targetScene.Length > 0)
            sceneName = targetScene;

        if(sceneListInBuild.Contains(sceneName)) { //Only attempt to load the scene if a taskName has been given
            SceneManager.LoadScene(sceneName);
            return;
        }

        logError("[" + sceneName + "] is NOT a scene in build settings");
    }
    
    private void logError(string errorMsg)
    {
        string taskError = "Task System ERROR: ";
        Debug.Log(taskError + errorMsg);
    }
}
