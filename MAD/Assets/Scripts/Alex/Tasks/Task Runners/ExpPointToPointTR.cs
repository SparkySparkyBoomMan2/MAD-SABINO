using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPointToPointTR : MonoBehaviour
{
    public TaskConfig taskConfig;

    private GameEvents gameEvents;

    private PointToPointConfig pConf;

    public void Start()
    {
        Setup();
        Run();
    }

    public void Setup()
    {
        gameEvents = new GameEvents("ScriptableObjects/Alex/Task Events/PointToPoint");
        gameEvents.Print();

        var moveGoal = gameEvents["Move Goal"];
        var moveHome = gameEvents["Move Home"];
        var moveStart = gameEvents["Move Start"];

 

        if(taskConfig != null) // && taskConfig.conf != null) 
        {
            if (taskConfig.conf == null)
                taskConfig.conf = new PointToPointConfig();

            pConf = taskConfig.conf as PointToPointConfig;

            moveGoal.sentVec3 = new Vector3(pConf.goalX, pConf.goalY, pConf.goalZ);
            moveGoal.Raise();

            moveStart.sentVec3 = new Vector3(pConf.startX, pConf.startY, pConf.startZ);
            moveStart.Raise();

            moveHome.sentVec3 = new Vector3(pConf.homeX, pConf.homeY, pConf.homeZ);
            moveHome.Raise();
        }
        else
        {
             Debug.LogErrorFormat("PointToPointTR: [taskConfig] is null!");
        }
    }

    public void Run()
    {   
        
        if(pConf.repeatNumber > -1) {
            pConf.decrementRepeat();
            resetAll();

            gameEvents["Go to Home"].Raise();
            // The event listener on TaskRunner takes care of the rest
            // each iteration/loop will come back to here!
        }
        else {
            gameEvents["Stop Task"].Raise();
        }
    }

    public void resetAll()
    {
        Debug.Log("Resetting all");
        gameEvents["Reset Goal"].Raise();
        gameEvents["Reset Start"].Raise();
        gameEvents["Reset Home"].Raise();
    }
}
