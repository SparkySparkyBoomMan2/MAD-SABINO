using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThatThang : MonoBehaviour
{
    public GameObject thingToRotate;
    public float rotateSpeed = 50f;

    void LateUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            thingToRotate.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
            print("We rotating");
        }
    }
}
