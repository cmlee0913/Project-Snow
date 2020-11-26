using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    new GameObject camera;
    GameObject player;
    GameObject cameraSpot;
    Rigidbody playerRigid;
    float mouseX;
    float mouseY;
    float x;
    float Horizontal;
    float Vertical;
    float speed;
    public bool isMove = false;
    public bool isJumping = false;
    float jumpPower = 2000f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        camera = GameObject.FindWithTag("Camera");
        cameraSpot = GameObject.FindWithTag("CameraSpot");
        playerRigid = player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Balance();
        Camera();
        //PlayerJump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Balance() // X, Z축의 회전값을 조정
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
        x = camAngle.x - mouseY; // 최대 카메라 각도 설정을 위한 변수

        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f); // -1도의 이유는 수평 부근에서의 멈춤을 막기위해
        }
        else if (180f <= x)
        {
            x = Mathf.Clamp(x, 335f, 361f); // 1도의 이유는 위와 같음
        }

        cameraSpot.transform.rotation = Quaternion.Euler(x, camAngle.y + mouseX, camAngle.z);
    }

    private void Move()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        speed = 5f;

        if (Input.GetKey(KeyCode.LeftShift) == true) // 대쉬 유무 판별
        {
            speed = 10f;
        }
        else if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            speed = 5f;
        }

        if (Horizontal != 0 || Vertical != 0) // 방향키 입력 유무 판별
        {
            isMove = true;
        }

        Vector3 moveVertical = new Vector3(cameraSpot.transform.forward.x,
                                           0, // 이동 방향을 2차원적으로 고정 시키기 위해
                                           cameraSpot.transform.forward.z).normalized;
        Vector3 moveHorizontal = new Vector3(cameraSpot.transform.right.x,
                                             0, // 이동 방향을 2차원적으로 고정 시키기 위해
                                             cameraSpot.transform.right.z).normalized;
        Vector3 move = moveVertical * Vertical + moveHorizontal * Horizontal;

        if (isJumping == false) // 점프 중이 아닐 때
        {
            if (isMove == true)
            {
                player.transform.forward = move; // 플레이어의 시선 방향이 방향키 입력 방향과 일치하도록 회전
                transform.position += move * Time.deltaTime * speed; // 키보드 입력 시 camSpot의 전방 또는 좌우으로 이동
                isMove = false; // 시선 방향 고정
            }
        }
    }

    //private void PlayerJump()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) == true)
    //    {
    //        if (isJumping == false)
    //        {
    //            playerRigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    //            player.transform.position = transform.position;
    //            isJumping = true;
    //        }
    //    }
    //}

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Map") == true)
    //    {
    //        isJumping = false;
    //    }
    //}
}
// Reference https://www.youtube.com/watch?v=P4qyRyQdySw&t=510s