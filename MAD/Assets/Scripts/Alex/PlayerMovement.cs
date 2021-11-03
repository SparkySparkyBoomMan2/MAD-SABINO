using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private float xMin = -0.05f, xMax = 0.05f, yMin = -0.05f, yMax = 0.05f;
    
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

        Debug.Log("clampedXAxis: " + clampedXAxis);
        Debug.Log("clampedYAxis: " + clampedYAxis);

        Vector3 movement = new Vector3(clampedXAxis, 0.0f, clampedYAxis);
        GetComponent<Rigidbody>().AddForce(movement*speed*Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            score++;
            other.gameObject.SetActive(false);
        }
    }
}
