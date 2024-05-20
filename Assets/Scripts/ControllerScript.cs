using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public Camera sceneCamera;
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private float step;

    void centerCube()
    {
        targetPosition = sceneCamera.transform.position + sceneCamera.transform.forward * 3.0f;
        targetRotation = Quaternion.LookRotation(transform.position - sceneCamera.transform.position);

        transform.position = Vector3.Lerp(transform.position, targetPosition, step);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, step);
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = sceneCamera.transform.position + sceneCamera.transform.forward * 3.0f;
        Debug.Log("Start Controller");
    }

    // Update is called once per frame
    void Update()
    {
        step = 5.0f * Time.deltaTime;
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            centerCube();
            Debug.Log("Centering cube");
        }

        if (OVRInput.Get(OVRInput.RawButton.RThumbstickLeft)) transform.Rotate(0, 5.0f * step, 0);
        if (OVRInput.Get(OVRInput.RawButton.RThumbstickRight)) transform.Rotate(0, -5.0f * step, 0);

        if (OVRInput.GetUp(OVRInput.Button.One))
        {
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
        }

        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.0f)
        {
            transform.position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
            transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);
        }
    }
}
