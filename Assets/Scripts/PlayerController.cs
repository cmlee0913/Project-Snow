using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigid;
    public GameObject player;
    public float speed;
    public float jumpPower;
    public float moveHorizontal;
    public float moveVertical;
    public float mouseHorizontal;
    public float mouseVertical;
    public float moveUp;
    public Vector3 movement;
    public Vector3 rotate;

    void Start() {
        playerRigid = GetComponent<Rigidbody>();
    }

    void Update() {
        Jump();
        Dash();
    }

    void FixedUpdate() {
        Move();
    }

    void Move() {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0, moveVertical);

        //playerRigid.AddForce(movement * speed, ForceMode.Acceleration);
        playerRigid.velocity = movement * speed;
    }

    void Jump() {
        moveUp = Input.GetAxis("Jump");

        movement = new Vector3(0, moveUp, 0);

        playerRigid.AddForce(jumpPower * movement, ForceMode.Acceleration);
    }

    void Dash() {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10;
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5;
        }
    }

    //void Rotate() {
    //    mouseHorizontal = Input.GetAxis("Mouse X");

    //    transform.Rotate(new Vector3(0, mouseHorizontal * 2, 0), Space.Self);
    //}
}
