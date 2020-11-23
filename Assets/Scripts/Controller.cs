using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public new GameObject camera;
    public GameObject player;
    public GameObject cameraSpot;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        camera = GameObject.FindWithTag("Camera");
        cameraSpot = GameObject.FindWithTag("CameraSpot");
    }

    private void Update()
    {
        Balance();
        Camera();
    }

    private void FixedUpdate()
    {

    }

    private void Balance()
    {
        Quaternion playerRotation = player.transform.localRotation;

        if ((playerRotation.eulerAngles.x == 0 || playerRotation.eulerAngles.z == 0) == false)
        {
            playerRotation.eulerAngles = new Vector3(0, playerRotation.eulerAngles.y, 0);
        }
    }

    private void Camera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 camAngle = cameraSpot.transform.rotation.eulerAngles;
        float x = camAngle.x - mouseY;

        if(x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }

        cameraSpot.transform.rotation = Quaternion.Euler(x, camAngle.y + mouseX, camAngle.z);
    }
}
