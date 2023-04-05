using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField] private float _moveSpeed = 8f, _gravityScale = -9.81f;


    private Vector3 _movementVelocity;
    private float _verticalVelocity;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        CalculateMovement();
        if (_controller.isGrounded == false)
        {
            _verticalVelocity = _gravityScale * Time.fixedDeltaTime;
        }
        Vector3 move = _movementVelocity + _verticalVelocity * Vector3.up;
        _controller.Move(transform.TransformDirection(move));
    }
    public void StopImmediately()
    {
        _movementVelocity = Vector3.zero;
    }
    public void SetMovementVelocity(Vector3 velocity)
    {
        this._movementVelocity = velocity;
    }

    private void CalculateMovement()
    {
        _movementVelocity.Normalize();
        _movementVelocity *= _moveSpeed * Time.fixedDeltaTime;
    }
}
