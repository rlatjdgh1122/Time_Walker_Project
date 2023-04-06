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
    public static bool FaceDetect(this bool facBool, float attackDistance, out bool isRotate, Transform trm)
    {
        RaycastHit hit;
        if (Physics.Raycast(trm.position,
           trm.forward, out hit, attackDistance))
        {
            if (hit.collider.CompareTag("Player")) //플레이어가 맞으면 로테이트를 꺼주고 트루를 반환
            {
                //if (Vector3.Distance(hit.point, hit.collider.bounds.center) < 0.2f)
                {
                    isRotate = false;
                    return true;
                }
            }
        }
        isRotate = true;
        return false;
    }
}
