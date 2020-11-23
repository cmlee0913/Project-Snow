using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F2Player : MonoBehaviour
{
    public new GameObject camera;
    public GameObject player;
    public GameObject TPScontroller;
    public Rigidbody rigid;
    public Rigidbody playerRigid;
    public bool isJumping = false;
    public float jumpPower = 2000f;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        camera = GameObject.FindWithTag("Camera");
        TPScontroller = GameObject.FindWithTag("TPScontroller");
        rigid = TPScontroller.GetComponent<Rigidbody>();
        playerRigid = player.GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        Balance();
        PlayerJump();
        //PlayerRotate();
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    void Balance()
    {
        Quaternion playerRotation = player.transform.localRotation;

        if ((playerRotation.eulerAngles.x == 0 || playerRotation.eulerAngles.z == 0) == false)
        {
            playerRotation.eulerAngles = new Vector3(0, playerRotation.eulerAngles.y, 0);
        }
    }

    void PlayerMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float speed = 5f;

        if (Input.GetKey(KeyCode.LeftShift) == true)
        {
            speed = 20f;
        }
        else if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            speed = 10f;
        }

        if (isJumping == false)
        {
            rigid.velocity = new Vector3(horizontal, 0f, vertical) * speed;
            playerRigid.velocity = new Vector3(horizontal, 0f, vertical) * speed;
        }
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            if (isJumping == false)
            {
                playerRigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                isJumping = true;
            }
        }
    }

    //void PlayerRotate()
    //{

    //    player.transform.eulerAngles = new Vector3(0,


    //}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Map") == true)
        {
            isJumping = false;
        }
    }
}
