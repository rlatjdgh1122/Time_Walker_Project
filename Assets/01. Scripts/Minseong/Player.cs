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

        // ���콺 ����
        currentRot -= rotX;

        // ���콺�� Ư�� ������ �Ѿ�� �ʰ� ����ó��
        currentRot = Mathf.Clamp(currentRot, -80f, 80f);

        // Camera�� Player�� �ڽ��̹Ƿ� �÷��̾��� Y�� ȸ���� Camera���Ե� �Ȱ��� �����
        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);
        // Camera�� transform ������Ʈ�� ���÷����̼��� ���Ϸ����� 
        // ����X�� �����̼��� ��Ÿ���� ���Ϸ����� �Ҵ����ش�.
        fpsCam.transform.localEulerAngles = new Vector3(currentRot, 0f, 0f);
    }
}
