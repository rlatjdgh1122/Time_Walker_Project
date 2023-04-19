using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    private CharacterController _controller;
    private PlayerAttack _playerAttack;

    [SerializeField] private float _moveSpeed = 8f, _gravityScale = -9.81f;


    private Vector3 _movementVelocity;
    private Vector3 _dashVelocity;
    private float _verticalVelocity;
    private PlayerActionData _actionData;
    public bool isMove = false;

    private void Awake(){
        _controller = GetComponent<CharacterController>();
        _playerAttack = GetComponent<PlayerAttack>();
        _actionData = transform.Find("ActionData").GetComponent<PlayerActionData>();
    }

    private void FixedUpdate(){
        CalculateMovement();
        CalculateTimeScale();

        Vector3 move = _movementVelocity + _verticalVelocity * Vector3.up;
        _controller.Move(transform.TransformDirection(move));
        _controller.Move(_dashVelocity);
    }

    private void CalculateMovement(){
        _movementVelocity.Normalize();
        _movementVelocity *= _moveSpeed * Time.fixedDeltaTime;
    }
    public void StopImmediately(){
        _movementVelocity = Vector3.zero;
        _dashVelocity = Vector3.zero;
    }
    public void SetDashVelocity(Vector3 velocity){
        _dashVelocity = velocity;
    }
    public void SetMovementVelocity(Vector3 velocity){
        this._movementVelocity = velocity;
    }
    


    public void CalculateTimeScale(){
        if(_actionData.isAttacking || _controller.isGrounded == false){
            Debug.Log("IsGrounded: " + _controller.isGrounded);
            TimeController.Instance.SetTimeScale(1f,true);
            if(_controller.isGrounded == false)
                _verticalVelocity = _gravityScale * Time.fixedDeltaTime;
            return;
        }
        if(_movementVelocity.magnitude > 0.00001f){
            Debug.Log("Player is Moving");
            TimeController.Instance.SetTimeScale(1f,true);
            isMove = true;
        }
         else if(_movementVelocity.magnitude < 0.0001f){ //움직이지 않을때
            if(TimeController.Instance.GetCurrentTime() < 0.05f){
                TimeController.Instance.SetTimeScale(1f, false);
            }

            else{
                TimeController.Instance.SetTimeScale(0.1f,false);
                isMove  = false;
            }
        }
    }
}
