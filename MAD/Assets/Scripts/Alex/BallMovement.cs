using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public float speed;
    private float xMin = -0.1f, xMax = 0.1f, yMin = -0.1f, yMax = 0.1f;
    
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        float clampedXAxis = Mathf.Clamp(xAxis, xMin, xMax);
        float clampedYAxis = Mathf.Clamp(yAxis, yMin, yMax);

        // Debug.Log("clampedXAxis: " + clampedXAxis);
        // Debug.Log("clampedYAxis: " + clampedYAxis);

        Vector3 movement = new Vector3(clampedXAxis, 0.0f, clampedYAxis);
        GetComponent<Rigidbody>().AddForce(movement*speed*Time.deltaTime);
    }
}
