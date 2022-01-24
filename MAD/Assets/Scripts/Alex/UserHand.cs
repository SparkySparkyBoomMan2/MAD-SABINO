using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserHand : MonoBehaviour
{
    private GameObject handBone;
    private Transform handDetector;
 
    private Vector3 handBoneLastPosition;
    public string handBonePath;

    // void Awake() {
    //     AssignObjects();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if(handDetector.position != handBoneLastPosition) {
    //         UpdatePosition();
    //     }   
    // }

    // void AssignObjects() {
    //     handBone = GameObject.Find(handBonePath); //Performance implication?
    //     handDetector = this.transform;
    // }

    // void UpdatePosition() {
    //     handBoneLastPosition = handBone.transform.position;
    //     handDetector.position = handBone.transform.position;
    // }
}
