using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigid;
    public GameObject player;
    public float speed;
    public float maxSpeed;
    public float moveHorizontal;
    public float moveVertical;
    public Vector3 movement;
    public Vector3 playerVector3;

    void Start() {

    }

    void FixedUpdate() {

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3(moveHorizontal, 0, moveVertical);

        playerRigid.AddForce(movement*speed);

    }
}
