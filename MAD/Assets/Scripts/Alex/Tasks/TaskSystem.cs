using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class TaskSystem : Singleton
{
    private void Start()
    {
        // On start, get all scenes in the build settings, and add to a list
        GetAllScenes(sceneListInBuild);
        onLoadSceneEvent += LoadScene; // Subscribe the load scene method to the load scene event
    }

    // Private list to store all scenes in the build settings
    // - Static, so there is only one instance of this List and it is shared
    private static List<string> sceneListInBuild = new List<string>();

    // Events?
    public static event Action<string, TaskConfig> onLoadSceneEvent; // Define event that gets "broadcasted"
    public static void LoadSceneEvent(string scene, TaskConfig tconf) // method that "broadcasts" the event
    {
        onLoadSceneEvent?.Invoke(scene, tconf); // broadcast the event
    }


    // Loads a specifc task scene, if it exists in the build settings
    // ***** SCENE MUST BE IN BUILD SETTINGS TO WORK *****
    private void LoadScene(string targetScene, TaskConfig tconf)
    {
        // foreach (var sName in sceneListInBuild)
        // {
        //     Debug.Log(sName);
        // }

        //Only attempt to load the scene if a taskName has been given
        if(sceneListInBuild.Contains(targetScene)) { 
            StartCoroutine(LoadSceneAsync(targetScene));
            return;
        }

        Debug.LogErrorFormat("Task System: [" + targetScene + "] is NOT a scene in build settings");
    }

    // Inspired heavily from...
    // http://answers.unity.com/answers/1394340/view.html
    // Loop through all scenes in the build settings, and add the scene names to a list
    // ... passed in as an argument
    private void GetAllScenes(List<string> sceneList) 
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        
        // For each scene
        for(int i = 0; i < sceneCount; i++) 
        {
            // - find the path which the scene in the build settings is stored at
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);

            // - serach the path, to find the index of the final level the actual scene is stored at
            int slashIndex = scenePath.LastIndexOf("/");

            // - take a substring of the scene name from "/SceneTest.blah", to "SceneTest"
            // - ... and add it to the list
            sceneListInBuild.Add(scenePath.Substring(slashIndex+1, scenePath.LastIndexOf(".") - slashIndex-1));
        }
    }

    // Loads a scene correpsonding to the name passed in, asynchronously
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // Begin loading the scene asynchonously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        
        // Wait for the scene to finish loading
        while(!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
