using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject player;
    public Vector3 cameraVec;
    public Vector3 playerVec;

    //public float mx;
    //public float my;
    //public float mouseHorizontal;
    //public float mouseVertical;
    //public float rotSpeed = 200;


    void Start() {
        player = GameObject.FindWithTag("Player");
    }

    void Update() {
        Lookat();
    }
    public void Lookat ()
    {
        cameraVec = transform.position;
        playerVec = player.transform.position;

        if (cameraVec.x != playerVec.x)
        {
            cameraVec.x = playerVec.x;
        }

        if (cameraVec.y - playerVec.y != 2.5)
        {
            cameraVec.y = playerVec.y + 1.5f;
        }

        if (cameraVec.z - playerVec.z != -3.2)
        {
            cameraVec.z = playerVec.z - 3.2f;
        }

        transform.position = cameraVec;
    }
    void Mouses()
    {
        //mouseHorizontal = Input.GetAxis("Mouse X");
        //mouseVertical = Input.GetAxis("Mouse Y");
        //camTransform.LookAt(playerTransform);

        //mx += mouseHorizontal * rotSpeed * Time.deltaTime;
        //my += mouseVertical * rotSpeed * Time.deltaTime;

        //if (my >= 90)
        //{
        //    my = 90;
        //}
        //else if (my <= -90)
        //
        //    my = -90;
        //}

        //my = Mathf.Clamp(my, -90, 90);

        //camTransform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
