using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerMeterScript : MonoBehaviour {
    
    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image content;

    private BallController ballScript;


	// Use this for initialization
	void Start () {
        GameObject ball = GameObject.Find("Ball");
        ballScript = ball.GetComponent<BallController>();
    }
	
	// Update is called once per frame
	void Update () {
        HandleBar();
	}

    private void HandleBar()
    {
        content.fillAmount = Map(ballScript.getPower(), 0, 500, 0, 1);
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
