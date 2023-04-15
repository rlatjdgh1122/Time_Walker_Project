using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class ExpandMethod
{
    public static bool AttackDetect(this Collider[] col, float attackRadius, Vector3 pos)
    {
        col = Physics.OverlapSphere(pos, attackRadius, 1 << LayerMask.NameToLayer("Player"));
        if (col.Length > 0)
        {
            return true;
        }
        else return false;
    }
    public static bool FaceDetect(this bool facBool, float attackDistance, out bool isRotate, Transform trm)
    {
        RaycastHit hit;
        if (Physics.Raycast(trm.position + Vector3.up,
           trm.forward, out hit, attackDistance))
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.CompareTag("Player")) //플레이어가 맞으면 로테이트를 꺼주고 트루를 반환
            {
                isRotate = false;
                return true;
            }
        }
        isRotate = true;
        return false;
    }
}
