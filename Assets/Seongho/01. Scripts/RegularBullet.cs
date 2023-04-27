using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.Rendering.DebugUI;

public class RegularBullet : PoolableMono
{
    [SerializeField]
    private BulletDataSO bulletData;
    private float timeToLive = 0;

    private Rigidbody rigid;
    private bool isDead = false;

    private TrailRenderer trailRenderer;
    private void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        rigid = GetComponent<Rigidbody>();

        trailRenderer.enabled = true;
    }
    private void Update()
    {
        //  transform.rotation = rot;
        timeToLive += Time.deltaTime;
        transform.Translate(-Vector3.forward * bulletData.bulletSpeed * Time.deltaTime);

        if (timeToLive >= bulletData.lifeTime)
        {
            isDead = true;
            //PoolManager.Instance.Push(this);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (isDead) return;
        //맞은게 아군에게 맞은건지 전군에게 맞은건지 체크
        //맞은게 장애물인지 적인지 체크
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            HitObstacle(collision);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            HitPlayer(collision);
        }
        isDead = true;
        PoolManager.Instance.Push(this);
    }
    private void HitObstacle(Collider collision)
    {
        if (collision != null)
        {
        }
    }
    private void HitPlayer(Collider collision)
    {
        if (collision != null)
        {

        }
    }
    public void SetPositionAndRotation(Vector3 pos, Quaternion rot)
    {
        transform.position = pos;
        transform.rotation = rot;
    }
    public override void Init()
    {
        timeToLive = 0;
        isDead = false;
        trailRenderer.enabled = true;

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }
}
