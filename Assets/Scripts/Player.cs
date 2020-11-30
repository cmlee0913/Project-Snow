using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject TPScontroller;
    Rigidbody playerRigid;
    public bool isJumping;
    float jumpPower = 2000f;

    void Start()
    {
        TPScontroller = GameObject.FindWithTag("TPScontroller");
        playerRigid = GetComponent<Rigidbody>();
        isJumping = TPScontroller.GetComponent<Controller>().isJumping;
    }

    void Update()
    {
        PlayerJump();
    }

    private void PlayerJump()
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Map"))
        {
            isJumping = false;
        }
    }
}
