using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCursorController : MonoBehaviour {

    public Transform locator;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

        // Controls
        if (Input.GetKey("d"))
        {
            transform.RotateAround(locator.position, Vector3.up, 120 * Time.deltaTime);
            transform.LookAt(locator);
        }
        if (Input.GetKey("a"))
        {
            transform.RotateAround(locator.position, Vector3.up, -120 * Time.deltaTime);
            transform.LookAt(locator);
        }
	}
}
