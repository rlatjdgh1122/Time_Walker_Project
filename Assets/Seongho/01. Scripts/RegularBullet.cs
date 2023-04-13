using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.Rendering.DebugUI;

public class RegularBullet : PoolableMono
{
    public bool isEnemy; //���� ��??

    [SerializeField]
    private BulletDataSO bulletData;
    private float timeToLive;

    private Rigidbody rigid;
    private bool isDead = false;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //  transform.rotation = rot;
        timeToLive += Time.fixedDeltaTime;
        transform.Translate(-Vector3.right * bulletData.bulletSpeed * Time.deltaTime);

        if (timeToLive >= bulletData.lifeTime)
        {
            isDead = true;
            PoolManager.Instance.Push(this);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (isDead) return;
        //������ �Ʊ����� �������� �������� �������� üũ
        //������ ��ֹ����� ������ üũ
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            HitObstacle(collision);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            HitEnemy(collision);
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
    private void HitEnemy(Collider collision)
    {
        if (collision != null)
        {

        }
    }
    private Quaternion rot;
    public void SetPositionAndRotation(Vector3 pos, Quaternion rot)
    {
        transform.position = pos;
        transform.rotation = rot;
        //this.rot = Quaternion.Euler(rot);
    }
    public override void Init()
    {
        isDead = false;
        timeToLive = 0;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        rot = Quaternion.identity;
    }
}
