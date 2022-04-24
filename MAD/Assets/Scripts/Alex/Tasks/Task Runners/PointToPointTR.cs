using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointToPointTR : TaskRunner
{
    [SerializeField]
    private GameEvent moveGoal, moveStart, moveHome;

    [SerializeField]
    private GameEvent 
        goToGoal, goToStart, goToHome, 
        goalReached, startReached, homeReached,
        resetGoal, resetStart, resetHome;

    public int repeatTaskCount = 2;         // MIGUEL VILLANUEVA, 4/23
    private int count = 1;                  // MIGUEL VILLANUEVA, 4/23
    public GameObject home, start, goal;    // MIGUEL VILLANUEVA, 4/23
    public GameObject taskRunner;           // MIGUEL VILLANUEVA, 4/23
    public Material donePlastic;            // MIUGEL VILLANUEVA, 4/23
    public TMP_Text repeatText;             // MIGUEL VILLANUEVA, 4/24
    private float timer = 0.0f;             // MIUGEL VILLANUEVA, 4/24
    private bool timerIsRunning = false;    // MIGUEL VILLANUEVA, 4/24
    public TMP_Text timeText;               // MIGUEL VILLANUEVA, 4/24
    public GameObject panel;                // MIGUEL VILLANUEVA, 4/24
    public TMP_Text repeatResultText;       // MIGUEL VILLANUEVA, 4/24

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
        timerIsRunning = true;  // MIGUEL VILLANUEVA, 4/24
        Setup();
        Run();
    }

    public override void Setup()
    {
        if(taskConfig != null) // && taskConfig.conf != null) 
        {
            if (taskConfig.conf == null)
                taskConfig.conf = new PointToPointConfig();

            var pConf = taskConfig.conf as PointToPointConfig;

            moveGoal.sentVec3 = new Vector3(pConf.goalX, pConf.goalY, pConf.goalZ);
            moveGoal.Raise();

            moveStart.sentVec3 = new Vector3(pConf.startX, pConf.startY, pConf.startZ);
            moveStart.Raise();

            moveHome.sentVec3 = new Vector3(pConf.homeX, pConf.homeY, pConf.homeZ);
            moveHome.Raise();

            repeatTaskCount = pConf.repeats;    // MIGUEL VILLANUEVA, 4/23
            count = repeatTaskCount + 1;        // MIGUEL VILLANUEVA, 4/24
            repeatText.text = count.ToString(); // MIGUEL VILLANUEVA, 4/24
        }
        else
        {
             Debug.LogErrorFormat("PointToPointTR: [taskConfig] is null!");
        }
    }

    public override void Run()
    {
        // MIGUEL VILLANUEVA, 4/23
        if (count > 1)
        {
            count--;
            repeatText.text = count.ToString();
            resetAll();
            goToHome.Raise();
        }
        else
        {
            timerIsRunning = false;
            float minutes = Mathf.FloorToInt(timer / 60);
            float seconds = Mathf.FloorToInt(timer % 60);
            float milliseconds = (timer % 1) * 1000;
            count--;
            repeatText.text = count.ToString();
            //print("All done");
            home.GetComponent<MeshRenderer>().material = donePlastic;
            start.GetComponent<MeshRenderer>().material = donePlastic;
            goal.GetComponent<MeshRenderer>().material = donePlastic;
            taskRunner.GetComponent<EventListener>().enabled = false;
            home.GetComponent<EventListener>().enabled = false;
            start.GetComponent<EventListener>().enabled = false;
            goal.GetComponent<EventListener>().enabled = false;

            panel.SetActive(true);
            timeText.text = string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, milliseconds);
            repeatResultText.text = repeatTaskCount.ToString();

            return;
        }

        /* MIGUEL VILLANUEVA, 4/23
        // Put an if statement here for repeatTaskCount
        // Above do public int repeatTaskCount
        // In Setup() say repeatTaskCount = pConf.repeats;
        // Add int repeats in TaskConfig.cs
        resetAll();

        goToHome.Raise();
        // The event listener on TaskRunner takes care of the rest
        // each iteration/loop will come back to here!*/
    }

    public override void resetAll()
    {
        Debug.Log("Resetting all");
        resetGoal.Raise();
        resetStart.Raise();
        resetHome.Raise();
    }

}
