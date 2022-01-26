using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TaskSystem : MonoBehaviour
{
    void onAwake()
    {
        DontDestroyOnLoad(this);
    }
    public GameObject goal;
    public GameObject home;
    public GameObject start;
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

    // Loads the selected task and unloads the current scene
    public void loadTask(){
        if(taskName.Length > 0) { //Only attempt to load the scene if a taskName has been given
            SceneManager.LoadScene(taskName);
        }
    }
}
