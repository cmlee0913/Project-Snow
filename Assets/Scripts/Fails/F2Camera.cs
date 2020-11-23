using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F2Camera : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;
    public float distance;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        mainCamera = GameObject.FindWithTag("MainCamera");
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

void Update()
    {
        FollowingPlayerPos();
        CameraRotation();
    }

    void FixedUpdate()
    {
        
    }

    void FollowingPlayerPos() //here
    {
        distance = Vector3.Distance(player.transform.position, mainCamera.transform.position);
        Mathf.Clamp(distance, 3, 3);
    }

    void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");

        mainCamera.transform.RotateAround(player.transform.position, Vector3.up * mouseX, 0.1f);
    }
}
