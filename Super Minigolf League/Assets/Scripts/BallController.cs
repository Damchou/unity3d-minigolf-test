using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    //public GameObject pointerObject;
    //public Transform pointerTrans;
    public Text powerText;
    public Text shotsText;
    public float power = 250.0f;
    public int powerMin = 0;
    public int powerMax = 500;
    public GameObject pointer;

    private Rigidbody ball;
    private float ballVelocity;
    private int shots;
    public bool isMoving;

    private Vector3 lastPosition;

    //test
    

    MouseOrbitImproved camScript;

	// Use this for initialization
	void Start () {
        ball = GetComponent<Rigidbody>();
        shots = 0;
        setPowerText();
        setShotsText();

        GameObject mainCamera = GameObject.Find("Main Camera");
        camScript = mainCamera.GetComponent<MouseOrbitImproved>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //test


        // Checks Ball's velocity
        ballVelocity = ball.velocity.magnitude;

        // Controls Ball's isMoving value and Pointer's visibility
        if (ballVelocity < 0.1)
        {
            isMoving = false;
            //pointerObject.SetActive(true);
        } else
        {
            isMoving = true;
            //pointerObject.SetActive(false);
        }


 //------- Ball controls

        // Launch Ball
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("LMB pressed.");
            if (camScript.shooting && !isMoving)
            {
                Debug.Log("lastPosition check.");
                lastPosition = transform.position;
                Debug.Log("Ball not moving and beginning to add force.");
                ball.AddForce(pointer.transform.forward * -power*2);
                Debug.Log("Added Force.");
                shots++;
                Debug.Log("Added shots.");
                setShotsText();
                Debug.Log("Aaaand updated text. Done shooting.");
            }
        }

	}


    // Methods

    // Set Power
    public void setPower(float value)
    {
        if((power < powerMax && value > 0) || (power > powerMin && value < 0))
        {
            power += value * 10;
            if (power < powerMin)
                power = powerMin;

            if (power > powerMax)
                power = powerMax;

            powerText.text = "Power: " + power.ToString();
        }
    }

    // Get Power
    public float getPower()
    {
        return power;
    }

    // Get Ball's last static Position
    public Vector3 GetLastPosition()
    {
        return lastPosition;
    }

    // Updates UI-text
    void setPowerText()
    {
        powerText.text = "Power: " + power.ToString();
    }
    
    void setShotsText()
    {
        shotsText.text = "Shots: " + shots.ToString();
    }


}
