using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPointTR : TaskRunner
{
    [SerializeField]
    private GameEvent moveGoal, moveStart, moveHome;

    [SerializeField]
    private GameEvent 
        goToGoal, goToStart, goToHome, 
        goalReached, startReached, homeReached,
        resetGoal, resetStart, resetHome;

    public override void Start()
    {
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
        }
        else
        {
             Debug.LogErrorFormat("PointToPointTR: [taskConfig] is null!");
        }
    }

    public override void Run()
    {
        resetAll();

        goToHome.Raise();
        // The event listener on TaskRunner takes care of the rest
        // each iteration/loop will come back to here!
    }

    public override void resetAll()
    {
        Debug.Log("Resetting all");
        resetGoal.Raise();
        resetStart.Raise();
        resetHome.Raise();
    }

}
