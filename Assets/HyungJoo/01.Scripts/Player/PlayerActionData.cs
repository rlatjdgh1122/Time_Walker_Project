using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionData : MonoBehaviour{
    public bool isAttacking;
    public bool isGrounded;
    public bool isMoving;
    public bool isDashing;
    public bool chargingDash;
    public bool chargingSlash;

    public bool canDash;

    public Vector3 hitPos;
    public Vector3 hitNormal;
}