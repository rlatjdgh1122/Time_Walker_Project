using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField]
    private float _attackPower;

    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("WALL")){
            
        }
        PoolableMono obj = PoolManager.Instance.Pop("EnemyHItParticle");

        obj.GetComponent<HitParticle>().SpawnParticle(other.collider.transform.position);
    }
}
