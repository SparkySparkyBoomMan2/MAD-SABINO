using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Inheirts from the base class TaskRunner
public class PointToPointTR : TaskRunner
{

    // All of these are events, this is how we communicate and make actions happen within the task environment
    [SerializeField]
    private GameEvent moveGoal, moveStart, moveHome,
        goToGoal, goToStart, goToHome, 
        goalReached, startReached, homeReached,
        resetGoal, resetStart, resetHome,
        stopTask, hideHome;

    // A private referernce to the specifc type of config this task uses
    private PointToPointConfig pConf;

    /* Default values for testing from inspector. 
     * These should only be used if the config was not created already from the menu scene
     */
    public int runTaskCount = 1;         // MIGUEL VILLANUEVA, 4/23
    public bool useHome = true;

    // Variables to track the running time, and the changing text on screen
    public TMP_Text runText;             // MIGUEL VILLANUEVA, 4/24
    private float timer = 0.0f;             // MIUGEL VILLANUEVA, 4/24
    private bool timerIsRunning = false;    // MIGUEL VILLANUEVA, 4/24
    public TMP_Text timeText;               // MIGUEL VILLANUEVA, 4/24
    public TMP_Text runResultText;       // MIGUEL VILLANUEVA, 4/24

    // MIGUEL VILLANUEVA, 4/24
    void Update()
    {
        if (timerIsRunning)
        {
            timer += Time.deltaTime;
        }
    }

    public override void Start()
    {
        // timerIsRunning = true;  // MIGUEL VILLANUEVA, 4/24
        Setup();
        Run();
    }

    public override void Setup()
    {
        if(taskConfig != null) // && taskConfig.conf != null) 
        {
            timerIsRunning = true;  // MIGUEL VILLANUEVA, 4/24 // Alex Peña 4/25/22

            // Intialize a new PtPConfig only if one is not already created.
            // (This should only happen when directly running the task from its own scene)
            // (If loaded through the menu as normal, the menu will have created a config)
            if (taskConfig.conf == null) {
                // taskConfig is the ScriptableObject
                // .conf is the reference to the specific configuration we are using
                taskConfig.conf = new PointToPointConfig();
                pConf = taskConfig.conf as PointToPointConfig;
                pConf.runs = runTaskCount;
                pConf.useHome = useHome;
            }
            else{
                pConf = taskConfig.conf as PointToPointConfig;
            }

            // As part of the setup function, we read the x,y,z positions
            // Then, send these vectors through the moveGoal, moveStart, and moveHome events
            moveGoal.sentVec3 = new Vector3(pConf.goalX, pConf.goalY, pConf.goalZ);
            moveGoal.Raise();

            moveStart.sentVec3 = new Vector3(pConf.startX, pConf.startY, pConf.startZ);
            moveStart.Raise();

            // Only setup the home object if the TaskConfig speicifed that the home position is to be used. 
            if(pConf.useHome) {
                moveHome.sentVec3 = new Vector3(pConf.homeX, pConf.homeY, pConf.homeZ);
                moveHome.Raise();
            }
            else{
                hideHome.Raise();
            }

            // runTaskCount = pConf.runs;    // MIGUEL VILLANUEVA, 4/23
            // count = runTaskCount + 1;        // MIGUEL VILLANUEVA, 4/24
            // runText.text = count.ToString(); // MIGUEL VILLANUEVA, 4/24
            runText.text = pConf.runs.ToString(); // MIGUEL VILLANUEVA, 4/24 // Alex Peña 4/25/22
            runResultText.text = pConf.runs.ToString();
        }
        else
        {
             Debug.LogErrorFormat("PointToPointTR: [taskConfig] is null!");
        }
    }

    public override void Run()
    {
        runText.text = pConf.runs.ToString();
        // MIGUEL VILLANUEVA, 4/23 // Alex Peña 5/25
        // If there are more runs of the task left
        if (pConf.runs > 0)
        {
            // Decrement the number of runs left, and reset all objects in the scene
            pConf.runs--;
            resetAll();

            // If we are using the home position, raise the event to go there. Else, go to the start position
            if(pConf.useHome)
                goToHome.Raise();
            else
                goToStart.Raise();
        }
        else
        {
            timerIsRunning = false;
            float minutes = Mathf.FloorToInt(timer / 60);
            float seconds = Mathf.FloorToInt(timer % 60);
            float milliseconds = (timer % 1) * 1000;

            // Raise the event stop 
            stopTask.Raise();
          
            timeText.text = string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, milliseconds);
            return;

            /* IMPORTANT NOTE 
             * - The code seen below is extremely important. It is an example of changing objects within the scene. 
             * - You can see the home, start, and goal materials get set to their "done" material.
             * - This would require dragging in all objects (home, start, goal,etc) into the inspector, and having all of the code
             * inside the script to determine what takes place. 
             * - This code is rightly commented out because our system replaces the need for this. 
             *
             * - Instead, we use the goToHome.raise() events format. Calling the ".raise()" function fo an event will indeed, raise it. 
             * - Upon doing so, any objects in the scene that have the "EventListenerAndResposne" script on them, can drag this event into 
             * the inspector, and then specify a response for that event. This can be seen in action if you took at the "EventListenerAndResponse"
             * script placed on the TaskRunner, Goal, Home, and Start objects
             *
             *
             * - Our team truly hopes any future work with different tasks can be built off of this same system, as we beleive it to be quite powerful and modular. 
             *
             *
             *
            */

            /* Alex Pena 4/25/22 */
            // home.GetComponent<MeshRenderer>().material = donePlastic;
            // start.GetComponent<MeshRenderer>().material = donePlastic;
            // goal.GetComponent<MeshRenderer>().material = donePlastic;
            // taskRunner.GetComponent<EventListener>().enabled = false;
            // home.GetComponent<EventListener>().enabled = false;
            // start.GetComponent<EventListener>().enabled = false;
            // goal.GetComponent<EventListener>().enabled = false;
            // panel.SetActive(true);
            // runResultText.text = runTaskCount.ToString(); // Alex Peña 4/26/22
        }
    }

    public override void resetAll()
    {
        // Debug.Log("Resetting all");
        resetGoal.Raise();
        resetStart.Raise();
        resetHome.Raise();
    }
}
