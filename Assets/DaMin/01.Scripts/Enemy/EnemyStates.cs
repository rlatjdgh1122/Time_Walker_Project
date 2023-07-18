using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyStates
{
    public class Idle : State<EnemyMain>
    {
        public override void Enter(EnemyMain _entity)
        {
            Debug.Log($"{GetType().ToString()} : Idle");
            _entity.FindTarget();
        }

        public override void Execute(EnemyMain _entity)
        {
            if (_entity.CurrentTarget != null)
                _entity.ChangeState(EnemyState.chase);

            _entity.FindTarget();
        }

        public override void Exit(EnemyMain _entity)
        {

        }
    }

    public class Chase : State<EnemyMain>
    {
        public override void Enter(EnemyMain _entity)
        {
            Debug.Log($"{GetType().ToString()} : Chase");
        }

        public override void Execute(EnemyMain _entity)
        {
            if (_entity.CurrentTarget == null)
                _entity.ChangeState(EnemyState.idle);

            //if (_entity._agent.remainingDistance < 0.1f)
            _entity._agent.SetDestination(_entity.CurrentTarget.position);

            if (Vector3.Distance(_entity._curTarget.position, _entity.transform.position) <= _entity._attackRange || _entity.CurrentTarget == null)
                _entity.ChangeState(EnemyState.attack);
        }

        public override void Exit(EnemyMain _entity)
        {
            _entity._agent.ResetPath();
        }
    }

    public class Attack : State<EnemyMain>
    {
        private float _lastShotTime;
        public override void Enter(EnemyMain _entity)
        {
            Debug.Log($"{GetType().ToString()} : Attack");
            _lastShotTime = 0;
        }

        public override void Execute(EnemyMain _entity)
        {
            if (Time.time > _lastShotTime + _entity._timeToBtweenShot)
            {
                _lastShotTime = Time.time;
                Debug.Log("Attck");
            }

            if (Vector3.Distance(_entity._curTarget.position, _entity.transform.position) > _entity._attackRange || _entity.CurrentTarget == null)
                _entity.ChangeState(EnemyState.chase);

            Vector3 dir = _entity._curTarget.transform.position - _entity.transform.position;

            _entity.transform.rotation = Quaternion.Lerp(_entity.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * _entity._agent.acceleration);
        }

        public override void Exit(EnemyMain _entity)
        {

        }
    }
}
