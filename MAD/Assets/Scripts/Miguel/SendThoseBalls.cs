using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendThoseBalls : MonoBehaviour
{
    public TaskConfig taskConfig;
    public GameObject homeBall, startBall, goalBall;

    private float initHomeX, initHomeY, initHomeZ;
    private float initStartX, initStartY, initStartZ;
    private float initGoalX, initGoalY, initGoalZ;

    void Start()
    {
        initHomeX = homeBall.transform.position.x;
        initHomeY = homeBall.transform.position.y;
        initHomeZ = homeBall.transform.position.z;

        initStartX = startBall.transform.position.x;
        initStartY = startBall.transform.position.y;
        initStartZ = startBall.transform.position.z;

        initGoalX = goalBall.transform.position.x;
        initGoalY = goalBall.transform.position.y;
        initGoalZ = goalBall.transform.position.z;
    }

    public void SendItYeet()
    {
        var pConf = taskConfig.conf as PointToPointConfig;
        if (pConf == null)
            return;

        pConf.homeX = homeBall.transform.position.x - initHomeX;
        pConf.homeY = homeBall.transform.position.y - initHomeY;
        pConf.homeZ= homeBall.transform.position.z - initHomeZ;

        pConf.startX = startBall.transform.position.x - initStartX;
        pConf.startY = startBall.transform.position.y - initStartY;
        pConf.startZ = startBall.transform.position.z - initStartZ;

        pConf.goalX = goalBall.transform.position.x - initGoalX;
        pConf.goalY = goalBall.transform.position.y - initGoalY;
        pConf.goalZ = goalBall.transform.position.z - initGoalZ;
    }
}
