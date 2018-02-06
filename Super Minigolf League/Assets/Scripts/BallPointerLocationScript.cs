using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPointerLocationScript : MonoBehaviour {

    public Transform target;

    private Vector3 targetPosition;
    private MouseOrbitImproved camScript;

	// Use this for initialization
	void Start () {
        GameObject mainCamera = GameObject.Find("Main Camera");
        camScript = mainCamera.GetComponent<MouseOrbitImproved>();
    }
	
	// Update is called once per frame
	void Update () {

        if (camScript.shooting)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        this.transform.position = target.position;
        targetPosition = new Vector3(Camera.main.transform.position.x, this.transform.position.y, Camera.main.transform.position.z);
        this.transform.LookAt(targetPosition);
	}
}
