using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    
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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
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
