using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class AirCraftController : MonoBehaviour
{
    [SerializeField] public float throttleIncrease = 0.1f;
    [SerializeField] public float throttleMax = 200f;
    [SerializeField] public float responsiveness = 10f;

    [SerializeField] public float throttle;
    [SerializeField] private float roll;
    [SerializeField] private float pitch;
    [SerializeField] private float yaw;
    [SerializeField] public float lift = 135f;

    public XRJoystick joystick;
    public XRKnob knob;
    
    [SerializeField] Transform propeller;

    private float ResModifier
    {
        get
        {
            return (rb.mass / 10f) * responsiveness;
        }
    }
   
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
      
    }

    private void HandleInput()
    {
        roll = joystick.value.x;   // Horizontal joystick movement for Roll
        pitch = joystick.value.y;  // Vertical joystick movement for Pitch

        // Using XR Knob for Yaw and Throttle
        yaw = knob.value; // Rotation value of knob for Yaw
        throttle = Mathf.Clamp(knob.value * throttleMax, 0f, throttleMax);
    }

    private void Update()
    {
        HandleInput();
        propeller.Rotate(Vector3.right * throttle);// to make a fan move with the engine im same direction
        
    }

    private void FixedUpdate() // used fixedupdate beacouse ian update in physics
    {
        //to add force to forward 
        rb.AddForce(transform.forward * throttleMax * throttle); 
        rb.AddTorque(transform.up * yaw * ResModifier);
        rb.AddTorque(transform.right * pitch * ResModifier);
        rb.AddTorque(-transform.forward * roll * ResModifier);
        rb.AddForce(Vector3.up * rb.velocity.magnitude * lift);
    }
}
