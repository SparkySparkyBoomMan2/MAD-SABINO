using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class init : MonoBehaviour
{
    public TaskConfig tConf;
    void Start()
    {
        tConf.conf = new PointToPointConfig();
    }

}
