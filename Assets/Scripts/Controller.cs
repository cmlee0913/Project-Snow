using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private new GameObject camera;
    private GameObject player;
    private GameObject cameraSpot;
    private Rigidbody playerRigid;
    private float mouseX;
    private float mouseY;
    private float x;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        camera = GameObject.FindWithTag("Camera");
        cameraSpot = GameObject.FindWithTag("CameraSpot");
        playerRigid = player.GetComponent<Rigidbody> ();
    }

    private void Update()
    {
        Balance();
        Camera();
    }

    private void FixedUpdate()
    {
        Move();
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
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        Vector3 camAngle = cameraSpot.transform.rotation.eulerAngles;
        x = camAngle.x - mouseY;

        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else if (180f <= x)
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }

        cameraSpot.transform.rotation = Quaternion.Euler(x, camAngle.y + mouseX, camAngle.z);
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float speed = 10;

        playerRigid.velocity = new Vector3(cameraSpot.transform.forward.x,
                                           0,
                                           cameraSpot.transform.forward.z).normalized * speed;
    }
}
// Reference https://www.youtube.com/watch?v=P4qyRyQdySw&t=510s