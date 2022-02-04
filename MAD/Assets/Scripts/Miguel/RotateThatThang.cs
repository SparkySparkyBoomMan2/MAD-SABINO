using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThatThang : MonoBehaviour
{
    public GameObject thingToRotate;
    public float rotateSpeed = 50f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            thingToRotate.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.S))
            thingToRotate.transform.Rotate(Vector3.down, rotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.A))
            thingToRotate.transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D))
            thingToRotate.transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.Q))
            thingToRotate.transform.Rotate(Vector3.left, rotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.E))
            thingToRotate.transform.Rotate(Vector3.right, rotateSpeed * Time.deltaTime);
    }
}
