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
    public float moveUp;
    public Vector3 movement;

    void Start() {
        playerRigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        Move();
    }
    void Update()
    {
        Jump();
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

        movement = new Vector3(moveHorizontal, moveUp, moveVertical);

        playerRigid.AddForce(jumpPower * movement, ForceMode.Acceleration);
    }
}
