using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOutScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            BallController ballScript = other.GetComponent<BallController>();
            Rigidbody ballBody = other.GetComponent<Rigidbody>();
            Debug.Log(":D falling, loser");
            ballBody.velocity = Vector3.zero;
            ballBody.angularVelocity = Vector3.zero;
            other.transform.position = ballScript.GetLastPosition();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
