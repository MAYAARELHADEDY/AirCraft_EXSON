using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ControllerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI throttle;
    [SerializeField] TextMeshProUGUI airspeed;
    [SerializeField] TextMeshProUGUI altitude;
    private AirCraftController aircraft;
    Rigidbody rb;
    private void Awake()
    {
        
        rb = GetComponent<Rigidbody>();
        aircraft = FindObjectOfType<AirCraftController>();
    }
    private void Update()
    {
        UpdateUI();


    }
    private void UpdateUI()
    {
        throttle.text = (aircraft.throttle).ToString("F0") +"%"; //speed
        airspeed.text = (rb.velocity.magnitude *3.6f).ToString("F0")+ "km/h"; //KE
        altitude.text = (aircraft.transform.position.y).ToString("F0")+ "m"; //PE  

    }
}
