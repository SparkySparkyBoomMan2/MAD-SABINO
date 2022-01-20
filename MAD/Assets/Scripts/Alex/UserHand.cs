using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserHand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var handBone = GameObject.Find("PlayerArmature/Skeleton/Hips/Spine/Chest/UpperChest/Right_Shoulder/Right_UpperArm/Right_LowerArm/Right_Hand");
        
        var userHandGoal = this.transform;

        userHandGoal.position = handBone.transform.position;
    }
}
