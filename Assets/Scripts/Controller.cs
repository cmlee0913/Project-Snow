using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    new GameObject camera;
    Camera mainCamera;
    GameObject player;
    GameObject cameraSpot;
    Rigidbody playerRigid;
    Vector3 controllerPos;
    float mouseX;
    float mouseY;
    float scroll;
    float x;
    float Horizontal;
    float Vertical;
    float speed;
    public bool isMove = false;
    public bool isJumping = false;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        camera = GameObject.FindWithTag("Camera");
        cameraSpot = GameObject.FindWithTag("CameraSpot");
        playerRigid = player.GetComponent<Rigidbody>();
        mainCamera = camera.GetComponent<Camera>();
        controllerPos = transform.position;
    }

    private void Update()
    {
        Balance();
        Camera();
        controllerPos.y = player.transform.position.y;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Balance() // X, Z축의 회전값을 조정
    {
        Quaternion playerRotation = player.transform.localRotation;

        /* 플레이어 X, Z회전 값 소숫점 반올림 */
        if ((playerRotation.eulerAngles.x == 0 || playerRotation.eulerAngles.z == 0) == false)
        {
            playerRotation.eulerAngles = new Vector3(0, playerRotation.eulerAngles.y, 0);
        }
    }

    private void Camera()
    {
        /* 변수 선언 */
        mouseX = Input.GetAxis("Mouse X") * 3f;
        mouseY = Input.GetAxis("Mouse Y") * 3f;
        scroll = -Input.GetAxis("Mouse ScrollWheel") * 10f;
        Vector3 camAngle = cameraSpot.transform.rotation.eulerAngles;
        x = camAngle.x - mouseY; // 최대 카메라 각도 설정을 위한 변수

        /* 마우스 휠로 카메라 줌 조절 */
        if (mainCamera.fieldOfView <= 20f && scroll < 0f)
        {
            mainCamera.fieldOfView = 20f;
        }
        else if (mainCamera.fieldOfView >= 60f && scroll >0f)
        {
            mainCamera.fieldOfView = 60f;
        }
        else
        {
            mainCamera.fieldOfView += scroll;
        }

        /* 회전 각도 최대 범위 설정 */
        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f); // -1도의 이유는 수평 부근에서의 멈춤을 막기위해
        }
        else if (180f <= x)
        {
            x = Mathf.Clamp(x, 355f, 361f); // 1도의 이유는 위와 같음
        }

        /* 마우스 움직임에 따라 CamSpot 회전 값 변경 */
        if (Input.GetMouseButton(1)) // 마우스 왼쪽버튼 누르면서 시점 이동
        {
            cameraSpot.transform.rotation = Quaternion.Euler(x, camAngle.y + mouseX, camAngle.z);
        }
    }

    private void Move()
    {
        /* 변수 선언 */
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        speed = 5f;

        /* 대쉬 유무 판별 */
        if (Input.GetKey(KeyCode.LeftShift) == true)
        {
            speed = 10f;
        }
        else if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            speed = 5f;
        }

        /* 방향키 입력 유무 판별 */
        if (Horizontal != 0 || Vertical != 0)
        {
            isMove = true;
        }

        /* 카메라 스팟의 전후방 좌우 방향을 기준 */
        Vector3 moveVertical = new Vector3(cameraSpot.transform.forward.x,
                                           0, // 이동 방향을 2차원적으로 고정 시키기 위해
                                           cameraSpot.transform.forward.z).normalized;
        Vector3 moveHorizontal = new Vector3(cameraSpot.transform.right.x,
                                             0, // 이동 방향을 2차원적으로 고정 시키기 위해
                                             cameraSpot.transform.right.z).normalized;
        Vector3 move = moveVertical * Vertical + moveHorizontal * Horizontal;

        /* 카메라 스팟의 전후방 좌우 방향으로 이동 */
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
}
// Reference https://www.youtube.com/watch?v=P4qyRyQdySw&t=510s
                                                               
                                                               