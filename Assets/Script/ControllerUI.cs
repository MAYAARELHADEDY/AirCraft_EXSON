using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ControllerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ke;
    private AirCraftController aircraft;

    private void Awake()
    {
        aircraft = FindObjectOfType<AirCraftController>();
    }
    private void Update()
    {
        UpdateUI();


    }
    private void UpdateUI()
    {
        ke.text = (aircraft.throttle).ToString("F0");

    }
}
