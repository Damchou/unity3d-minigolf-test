using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class MouseOrbitImproved : MonoBehaviour
{

    public Transform target;
    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public float distanceMin = .5f;
    public float distanceMax = 15f;

    public bool shooting = false;

    private Rigidbody rigidbody;
    private BallController ballScript;
    private GameObject pointer;
    public GameObject meter;
    public GameObject meterText;

    float x = 0.0f;
    float y = 0.0f;

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        rigidbody = GetComponent<Rigidbody>();
        Screen.lockCursor = true;

        GameObject ball = GameObject.Find("Ball");
        ballScript = ball.GetComponent<BallController>();

        pointer = GameObject.Find("BallPointerLocation");

        // Make the rigid body not change rotation
        if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }
    }

    void LateUpdate()
    {
        if (target)
        {

            // Activates/Deactivates "Shooting-control"
            if (Input.GetMouseButtonDown(0))
            {
                if (!ballScript.isMoving)
                {
                    shooting = !shooting;
                    pointer.gameObject.SetActive(shooting);
                    meter.SetActive(shooting);
                    meterText.SetActive(shooting);
                }
            }

            // Cancels "Shooting-control"
            if (Input.GetMouseButtonDown(1))
            {
                shooting = false;
                meter.SetActive(shooting);
                meterText.SetActive(shooting);
            }
                
            

            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            if (!shooting)
            {
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            } else
            {
                ballScript.setPower(Input.GetAxis("Mouse Y"));
            }

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

            RaycastHit hit;
            if (Physics.Linecast(target.position, transform.position, out hit))
            {
                distance = hit.distance;
                Debug.Log("HIT");
            }
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }


}