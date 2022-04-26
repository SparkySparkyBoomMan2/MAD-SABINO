using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointToPointTR : TaskRunner
{
    [SerializeField]
    private GameEvent moveGoal, moveStart, moveHome,
        goToGoal, goToStart, goToHome, 
        goalReached, startReached, homeReached,
        resetGoal, resetStart, resetHome,
        stopTask, hideHome;

    private PointToPointConfig pConf;

    /* Default values for testing from inspector. 
     * These should only be used if the config was not created already from the menu scene
     */
    public int runTaskCount = 1;         // MIGUEL VILLANUEVA, 4/23
    public bool useHome = true;

    /* These are all located and caled in the event listener */
    // private int count = 1;                  // MIGUEL VILLANUEVA, 4/23
    // public GameObject home, start, goal;    // MIGUEL VILLANUEVA, 4/23
    // public GameObject taskRunner;           // MIGUEL VILLANUEVA, 4/23
    // public Material donePlastic;            // MIUGEL VILLANUEVA, 4/23
    // public GameObject Panel;// MIUGEL VILLANUEVA, 4/23 
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
                taskConfig.conf = new PointToPointConfig();
                pConf = taskConfig.conf as PointToPointConfig;
                pConf.runs = runTaskCount;
                pConf.useHome = useHome;
            }
            else{
                pConf = taskConfig.conf as PointToPointConfig;
            }

            moveGoal.sentVec3 = new Vector3(pConf.goalX, pConf.goalY, pConf.goalZ);
            moveGoal.Raise();

            moveStart.sentVec3 = new Vector3(pConf.startX, pConf.startY, pConf.startZ);
            moveStart.Raise();

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
        if (pConf.runs > 0)
        {
            pConf.runs--;
            resetAll();
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

            stopTask.Raise();
          
            timeText.text = string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, milliseconds);
            return;
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
