using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public Camera fpsCam;

    float moveSpeed;
    float rotSpeed;
    float currentRot;

    float xInput;
    float zInput;

    void Start()
    {
        moveSpeed = 5.0f;
        rotSpeed = 3.0f;
        currentRot = 0f;
    }

    void Update()
    {
        PlayerMove();
        RotCtrl();

        if(Mathf.Abs(xInput) > 0 || Mathf.Abs(zInput) > 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = Mathf.Clamp(new Vector2(xInput, zInput).magnitude,0.002f,100);
        }
    }

    void PlayerMove()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * moveSpeed;
        float zSpeed = zInput * moveSpeed;

        transform.Translate(Vector3.forward * zSpeed * Time.unscaledDeltaTime);
        transform.Translate(Vector3.right * xSpeed * Time.unscaledDeltaTime);
    }

    void RotCtrl()
    {
        float rotX = Input.GetAxis("Mouse Y") * rotSpeed;
        float rotY = Input.GetAxis("Mouse X") * rotSpeed;

        // 마우스 반전
        currentRot -= rotX;

        // 마우스가 특정 각도를 넘어가지 않게 예외처리
        currentRot = Mathf.Clamp(currentRot, -80f, 80f);

        // Camera는 Player의 자식이므로 플레이어의 Y축 회전은 Camera에게도 똑같이 적용됨
        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);
        // Camera의 transform 컴포넌트의 로컬로테이션의 오일러각에 
        // 현재X축 로테이션을 나타내는 오일러각을 할당해준다.
        fpsCam.transform.localEulerAngles = new Vector3(currentRot, 0f, 0f);
    }
}
