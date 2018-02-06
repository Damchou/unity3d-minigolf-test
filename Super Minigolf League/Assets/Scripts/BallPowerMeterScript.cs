using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPowerMeterScript : MonoBehaviour {

    public float barDisplay; //current progress
    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(60, 20);
    public Texture2D emptyTex;
    public Texture2D fullTex;

    private BallController ballScript;

    private void OnGUI()
    {
        //draw the background
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
            GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);

            //draw the filled-in part
            GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
                GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
            GUI.EndGroup();
        GUI.EndGroup();
    }

    // Use this for initialization
    void Start () {
        GameObject ball = GameObject.Find("Ball");
        ballScript = ball.GetComponent<BallController>();
    }
	
	// Update is called once per frame
	void Update () {
        barDisplay = ballScript.getPower();
	}
}
