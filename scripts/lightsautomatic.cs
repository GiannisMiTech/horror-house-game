using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsautomatic : MonoBehaviour
{
 public GameObject lightObject;
    public float toggleInterval ; // Time interval for toggling the light
    public float turnOffDelay ;   // Delay before turning off the light

    private bool isLightActive = false;

    void Start()
    {
        if (lightObject == null)
        {
            Debug.LogError("Light object not assigned. Please assign a GameObject with the light component in the inspector.");
            enabled = false;
            return;
        }

        // Start invoking the ToggleLightState method with the specified interval
        InvokeRepeating("ToggleLightState", 0f, toggleInterval);
    }

    void ToggleLightState()
    {
        // Toggle light state
        isLightActive = !isLightActive;
        UpdateLightState();

        // If the light is turned on, start the coroutine to turn it off after the specified delay
        if (isLightActive)
        {
            StartCoroutine(TurnOffAfterDelay());
        }
    }

    void UpdateLightState()
    {
        // Set the active state of the light GameObject based on the isLightActive variable
        lightObject.SetActive(isLightActive);
    }

    // Function to turn on the light
    public void TurnOn()
    {
        isLightActive = true;
        UpdateLightState();

        // Start the coroutine to turn off the light after the specified delay
        StartCoroutine(TurnOffAfterDelay());
    }

    // Function to turn off the light
    public void TurnOff()
    {
        isLightActive = false;
        UpdateLightState();
    }

    IEnumerator TurnOffAfterDelay()
    {
        yield return new WaitForSeconds(turnOffDelay);

        // Turn off the light after the delay
        TurnOff();
    }

}

