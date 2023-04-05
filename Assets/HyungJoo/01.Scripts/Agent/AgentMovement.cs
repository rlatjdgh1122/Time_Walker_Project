using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    private CharacterController _controller;
    private PlayerAttack _playerAttack;

    [SerializeField] private float _moveSpeed = 8f, _gravityScale = -9.81f;


    private Vector3 _movementVelocity;
    private float _verticalVelocity;

    public bool isMove = false;
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _playerAttack = GetComponent<PlayerAttack>();

    }

    private void FixedUpdate()
    {
        CalculateMovement();
        CalculateTimeScale();
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
    public void CalculateTimeScale(){
        if(_playerAttack.isAttacking){
            TimeController.Instance.SetTimeScale(1f,true);
            return;
        }
        if(_movementVelocity.magnitude < 0.05f){
            if(TimeController.Instance.GetCurrentTime() < 0.05f){
                TimeController.Instance.SetTimeScale(1f, false);
                return;
            }
            TimeController.Instance.SetTimeScale(0.1f,false);
            isMove  = false;
        }
        else{
            TimeController.Instance.SetTimeScale(1f,true);
            isMove = true;
        }
    }
}
