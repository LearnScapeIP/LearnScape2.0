using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Hover");
        // Set button text
        GetComponentInChildren<TextMesh>().text = "Hover over the button";
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the Controller's direction is pointing to the button
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            // Get the button's position
            Vector3 buttonPosition = transform.position;
            // Get the controller's position
            Vector3 controllerPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            // Get the controller's direction
            Vector3 controllerDirection = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) * Vector3.forward;
            // Get the controller's distance to the button
            float distance = Vector3.Distance(controllerPosition, buttonPosition);
            // Get the controller's direction to the button
            Vector3 direction = buttonPosition - controllerPosition;
            // Get the angle between the controller's direction and the button's direction
            float angle = Vector3.Angle(controllerDirection, direction);
            
            // Print the distance and angle
            Debug.Log("Distance: " + distance + " Angle: " + angle);

            // Update button's text to show distance and angle
            GetComponentInChildren<TextMesh>().text = "Distance: " + distance + "\nAngle: " + angle;

            // Check if the controller is pointing to the button
            if (distance < 100f && angle < 30.0f)
            {
                // Change the button's color
                GetComponent<Renderer>().material.color = Color.red;
                Debug.Log("Button pressed");

            } else {
                // Change the button's color
                GetComponent<Renderer>().material.color = Color.blue;
            }
        }
    }
}
