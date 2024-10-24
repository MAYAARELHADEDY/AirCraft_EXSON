using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCraftController : MonoBehaviour
{
    public float throttleIncrease = 0.1f;
    public float throttleMax = 200f;

    public float responsiveness = 10f;

    public float throttle;
    private float roll;
    private float pitch;
    private float yaw;
    public float lift = 135f;

    [SerializeField] Transform propella;
  
    private float resModifiter{
        get
        {
            return (rb.mass / 10f) * responsiveness;
        }

    }
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void HandleInput()
    {
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");

        if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrease;
        else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrease;
        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }

    private void Update()
    {
        HandleInput();

        propella.Rotate(Vector3.right * throttle);
        
       
     }
    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * throttleMax * throttle );
        rb.AddTorque(transform.up * yaw * resModifiter);
        rb.AddTorque(transform.right * pitch * resModifiter);
        rb.AddTorque(-transform.forward * roll * resModifiter);

        rb.AddForce(Vector3.up * rb.velocity.magnitude *lift);
    }
}
