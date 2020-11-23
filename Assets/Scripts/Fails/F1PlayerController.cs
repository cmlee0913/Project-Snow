using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F1PlayerController : MonoBehaviour {
    public Rigidbody playerRigid;
    public new GameObject camera;
    public GameObject pivot;
    Collision map;
    public float speed;
    public float jumpPower;
    public float moveHorizontal;
    public float moveVertical;
    public Vector3 movement;
    public Vector3 jump;
    public Vector3 rotate;
    public bool isJumping;
    public bool isDash;


    void Start() {
        Define();
    }

    void Update() {
        Isjumping();
        Isdash();
        Rotate();
    }

    void FixedUpdate() {
        Jump();
        Dash();
        Move();
    }

    void Define() {
        playerRigid = GetComponent<Rigidbody>();
        camera = GameObject.FindWithTag("MainCamera");
        pivot = GameObject.FindWithTag("P");
    }

    void Isjumping() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            isJumping = true;
        }
    }

    void Jump() {
        jump = new Vector3(0, 1, 0);

        if (isJumping == false) {
            return;
        }

        playerRigid.AddForce(jumpPower * jump,ForceMode.Impulse);

        isJumping = false;
    }

    void Isdash() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            isDash = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            isDash = false;
        }
    }

    void Dash() {
        if (isDash == true) {
            speed = 10;
        }
        else if (isDash == false) {
            speed = 5;
        }
    }

    void Move() {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");

            movement = new Vector3(moveHorizontal, 0, moveVertical);
            Vector3 dir = pivot.transform.rotation * movement;

            playerRigid.velocity = dir * speed; 
    }

    void Rotate()
    {
            transform.localRotation = new Quaternion(0,
                                                 camera.transform.localRotation.y,
                                                 camera.transform.localRotation.z,
                                                 camera.transform.localRotation.w);
    }
}
