using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class ExpandMethod
{
    public static bool AttackDetect(this Collider[] col, float attackRadius, Vector3 pos)
    {
        col = Physics.OverlapSphere(pos, attackRadius, LayerMask.GetMask("Player"));
        if (col.Length > 0)
        {
            return true;
        }
        else return false;
    }
    public static bool FaceDetect(this bool facBool, float attackDistance, out RaycastHit hit, Transform trm)
    {
        facBool = Physics.Raycast(trm.position + Vector3.up,
           trm.forward, out hit, attackDistance, LayerMask.GetMask("Player"));

        return facBool;
    }
}
