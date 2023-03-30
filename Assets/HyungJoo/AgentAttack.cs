using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAttack : MonoBehaviour
{
    [SerializeField]
    private int _damage;
    private PlayerAttack _playerAttack;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        _playerAttack = GetComponent<PlayerAttack>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag("ENEMY"))
        {
            if(!_playerAttack.isAttack) return;
            other.collider.GetComponent<AgentHP>().Damaged(_damage);
        }
    }
}
