using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    GameObject player;
    public Vector3 cameraPos;
    public Vector3 playerPos;
    public float mouseHorizontal;
    public float mouseVertical;
    public float angle;

    //public float mx;
    //public float my;
    //public float mouseHorizontal;
    //public float mouseVertical;
    //public float rotSpeed = 200;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        playerPos = player.transform.position;
        //Lookat();

    }

    void FixedUpdate()
    {
        Rotate();
    }
    //public void Lookat()
    //{
    //    cameraPos = transform.position;
    //    playerPos = player.transform.position;

    //    if (cameraPos.x != playerPos.x)
    //    {
    //        cameraPos.x = playerPos.x;
    //    }

    //    if (cameraPos.y - playerPos.y != 2.5)
    //    {
    //        cameraPos.y = playerPos.y + 1.5f;
    //    }

    //    if (cameraPos.z - playerPos.z != -3.2)
    //    {
    //        cameraPos.z = playerPos.z - 3.2f;
    //    }

    //    transform.position = cameraPos;
    //}

    void Rotate()
    {
        mouseHorizontal = Input.GetAxis("Mouse X");
        mouseVertical = Input.GetAxis("Mouse Y");

        transform.RotateAround(playerPos,
                               new Vector3(0, mouseHorizontal * 3, 0),
                               angle);
    }
}
