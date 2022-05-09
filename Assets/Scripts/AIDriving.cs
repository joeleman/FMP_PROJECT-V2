using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class AIDriving : MonoBehaviour
{
    // Defining variables
    public LayerMask layer;
    public WheelCollider wheelFR;
    public WheelCollider wheelFL;
    public WheelCollider wheelBR;
    public WheelCollider wheelBL;
    public GameObject wheelFRg;
    public GameObject wheelFLg;
    public GameObject wheelBRg;
    public GameObject wheelBLg;
    public float throttle;
    public float drivingforce;
    public float wheelangle;
    public Rigidbody rb;
    public Vector3 center;
    public Vector3 wheelpos;
    public Quaternion wheelrot;
    public Transform target;
    public Transform targeter;
    public float throttlecontrol;
    public float directional;
    public Vector3 reflection;
    public Transform right;
    public Transform left;
    public GameObject red;
    public GameObject blue;
    public bool lightchange;
    public float lighttime;
    // Start is called before the first frame update
    void Start()
    {
        rb.centerOfMass = center;
    }
 
    // Update is called once per frame
    void Update()
    {
        
        if(Mathf.Abs(directional) < 10)
        {
            throttlecontrol = 1;
        }
        else
        {
            throttlecontrol = 0.7f;
        }
       
        targeter.LookAt(target);
       
        if (targeter.localEulerAngles.y <= 180)
        {
            directional = Mathf.Clamp(targeter.localEulerAngles.y, -25, 25);
        }
        else
        {
            directional = Mathf.Clamp(targeter.localEulerAngles.y-360, -25, 25);
        }
        RaycastHit hit;
        if (Physics.Raycast(right.position, right.forward, out hit, 15 ))
        {
            directional = -25/(hit.distance/2);
        }
        if (Physics.Raycast(left.position, left.forward, out hit, 15))
        {
            directional = 25/(hit.distance/2);
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 4))
        {
            directional = -directional;
            throttlecontrol = -5;
        }
        drivingforce = throttlecontrol * throttle;
        wheelBR.motorTorque = drivingforce;
        wheelBL.motorTorque = drivingforce;
        wheelangle = directional;
 
        wheelFR.steerAngle = wheelangle;
        wheelFL.steerAngle = wheelangle;
 
        wheelFR.GetWorldPose(out wheelpos, out wheelrot);
        wheelFRg.transform.position = wheelpos;
        wheelFRg.transform.rotation = wheelrot;
 
 
        wheelFL.GetWorldPose(out wheelpos, out wheelrot);
        wheelFLg.transform.position = wheelpos;
        wheelFLg.transform.rotation = wheelrot;
 
 
        wheelBR.GetWorldPose(out wheelpos, out wheelrot);
        wheelBRg.transform.position = wheelpos;
        wheelBRg.transform.rotation = wheelrot;
 
 
        wheelBL.GetWorldPose(out wheelpos, out wheelrot);
        wheelBLg.transform.position = wheelpos;
        wheelBLg.transform.rotation = wheelrot;
    }
    void FixedUpdate()
    {
        rb.AddForce(-transform.up * rb.velocity.magnitude * 700);
        
        lighttime += 1;
        if (lighttime > 10)
        {
            lighttime = 0;
            if (lightchange == false)
            {
                lightchange = true;
                blue.SetActive(true);
                red.SetActive(false);
            }
            else
            {
                lightchange = false;
                blue.SetActive(false);
                red.SetActive(true);
            }
        }
    }
}
 