using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerDistanceDecision : AIDecision
{
    [SerializeField]
    private float _distance = 5f;

    public override bool MakeDecision()
    {
        if (_enemyController.TargetTrm == null) return true;

        float distance = Vector3.Distance(_enemyController.TargetTrm.position, transform.position);

        if (distance < _distance)  //시야 안으로 들어왔다면
        {
            _enemyMovement.isSetActive = true;
        }
        else
        {
            _enemyMovement.isSetActive = false;
        }
        return _enemyMovement.isSetActive;
    }
}
