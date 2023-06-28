using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour{
    private CharacterController _controller;
    protected AgentAnimator _agentAnimator;
    private PlayerAttack _playerAttack;

    [SerializeField] private float _moveSpeed = 8f, _gravityScale = -9.81f;
    [SerializeField] private LayerMask _layerMask;


    private Vector3 _movementVelocity;
    private Vector3 _dashVelocity;
    private float _verticalVelocity;

    private PlayerActionData _actionData;
    public bool isMove = false;

    private void Awake(){
        _controller = GetComponent<CharacterController>();
        _playerAttack = GetComponent<PlayerAttack>();
        _agentAnimator = GetComponent<AgentAnimator>();
        _actionData = transform.Find("ActionData").GetComponent<PlayerActionData>();
    }
    private void Update() {
        if(_movementVelocity.magnitude > 0.0001f){
            _actionData.isMoving = true;
        }
        else{
            _actionData.isMoving = false;
        }
    }
    private void FixedUpdate(){
        CalculateMovement();
        
        if(_controller.isGrounded == false){
            _verticalVelocity = _gravityScale * Time.fixedDeltaTime;
        }else{
            _verticalVelocity = _gravityScale * 0.2f * Time.fixedDeltaTime;
        }
        if(_actionData.isAttacking || _actionData.isDashing || _actionData.isSlashing){
            return;
        }

        Vector3 move = _movementVelocity + _verticalVelocity * Vector3.up;
        _controller.Move(transform.TransformDirection(move));
        _controller.Move(_dashVelocity);
    }
    private void CalculateMovement(){
        _agentAnimator.SetSpeed(_movementVelocity.sqrMagnitude);
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
}
