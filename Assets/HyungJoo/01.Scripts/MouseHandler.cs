using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static Core.Define;
using System;

public class MouseHandler : MonoBehaviour
{
    [SerializeField] private float _lookSpeed = 3f;
    private Camera _camera;
    private float _verticalLookRotation;

    private PlayerActionData _actionData;

    private void Awake()
    {
        _camera = MainCam;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _actionData = transform.Find("ActionData").GetComponent<PlayerActionData>();
    }
    private void Update()
    {
        if (_actionData.chargingSlash || _actionData.isSlashing) return;
        if (_actionData.chargingDash || _actionData.isDashing) return;
        if (_actionData.isAttacking) return;

        float mouseX = Input.GetAxis("Mouse X") * _lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * _lookSpeed;
        _verticalLookRotation -= mouseY;
        _verticalLookRotation = Mathf.Clamp(_verticalLookRotation, -90f, 90f);
        transform.Rotate(Vector3.up * mouseX);
        _camera.transform.localRotation = Quaternion.Euler(_verticalLookRotation, 0f, 0f);
    }
}
