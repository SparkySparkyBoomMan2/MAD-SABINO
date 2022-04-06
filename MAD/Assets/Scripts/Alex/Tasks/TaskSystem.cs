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
        onLoadSceneEvent += LoadScene; 
    }

    // store all scenes in the build settings
    private static List<string> sceneListInBuild = new List<string>();

    // Events?
    public static event Action<string, TaskConfig> onLoadSceneEvent;

    public static void LoadSceneEvent(string scene, TaskConfig tconf=null) // method that "broadcasts" the event
    {
        onLoadSceneEvent?.Invoke(scene, tconf); // broadcast the event
    }

    public static void LoadSceneEvent(string scene) // method that "broadcasts" the event
    {
        onLoadSceneEvent?.Invoke(scene, null); // broadcast the event
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

    // http://answers.unity.com/answers/1394340/view.html
    // Loop through all scenes in the build settings, and add the scene names to a list
    private void GetAllScenes(List<string> sceneList) 
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        
        // For each scene
        for(int i = 0; i < sceneCount; i++) 
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            int idx = scenePath.LastIndexOf("/");

            // - take a substring of the scene name from "/SceneTest.blah", to "SceneTest"
            // - ... and add it to the list
            sceneListInBuild.Add(scenePath.Substring(idx+1, scenePath.LastIndexOf(".") - idx-1));
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

    // Unloads a scene correpsonding to the name passed in, asynchronously
    private IEnumerator UnloadSceneAsync(string sceneName)
    {
        // Begin unloading the scene asynchonously
        AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(sceneName);

        // Wait for the scene to finish unloading
        while(!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
