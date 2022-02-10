using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThatThang : MonoBehaviour
{
    public GameObject thingToRotate;
    public float rotateSpeed = 50f;
    public bool rightControl = false;     // for multiplier
    public bool isUpper = false;        // for Vector3's

    private float multiplier = 1;
    private Vector3 w, s, a, d, e, q;


    void Start()
    {
        Init();
    }

    public void Init()
    {
        if (rightControl)
            multiplier = -1;
        else
            multiplier = 1;

        if (isUpper)
        {
            w = Vector3.up * multiplier;
            s = Vector3.down * multiplier;
            a = Vector3.forward * multiplier;
            d = Vector3.back * multiplier;
            e = Vector3.left;
            q = Vector3.right;
        }
        else
        {
            w = Vector3.left;
            s = Vector3.right;
            a = Vector3.up * multiplier;
            d = Vector3.down * multiplier;
            e = Vector3.forward * multiplier;
            q = Vector3.back * multiplier;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            thingToRotate.transform.Rotate(w, rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            thingToRotate.transform.Rotate(s, rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            thingToRotate.transform.Rotate(a, rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            thingToRotate.transform.Rotate(d, rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.E))
            thingToRotate.transform.Rotate(e, rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Q))
            thingToRotate.transform.Rotate(q, rotateSpeed * Time.deltaTime);
    }
}
