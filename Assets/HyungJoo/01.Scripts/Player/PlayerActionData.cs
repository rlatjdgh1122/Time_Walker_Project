using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionData : MonoBehaviour{
    public bool isAttacking;
    public bool isGrounded;
    public bool isMoving;

    public Vector3 hitPos;
    public Vector3 hitNormal;
}