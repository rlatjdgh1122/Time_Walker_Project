using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    public EnemySoData EnemySoData;

    public UnityEvent OnShooting;
    public UnityEvent<float, Transform, bool> OnMovement;

    private Rigidbody rigid;

    private Transform target;
    private CooldownManager cooldown = new CooldownManager();

    private bool isMove = true;

    private string cooltimeName = "EnemyAttackCoolTime";

    private Vector3 direction = Vector3.zero;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        target = GameManager.Instance.target.transform;
    }
    private void FixedUpdate()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }
    void Update()
    {
        direction = (target.position - transform.position).normalized;

        Rotation();
        Move();
    }

    private void Rotation()
    {
        Vector3 direction = target.localPosition
             - transform.localPosition;

        direction.y = 0;

        Quaternion rotation = Quaternion.LookRotation(direction);

        float lerpAmount = EnemySoData.weaponData.rotateSpeed * .02f;
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, lerpAmount);
    }

    private void Move()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance < EnemySoData.weaponData.attackRadius
         && HideInWalk() == false)
        {
            float attackDistance = Vector3.Distance(target.position, transform.position);
            if (attackDistance < EnemySoData.weaponData.shootDistance
                && HideInWalk() == false)
                Shooting();

            isMove = false;
        }
        else isMove = true;

         OnMovement?.Invoke(EnemySoData.weaponData.speed, target, isMove);
    }
    private bool HideInWalk()
    {
        RaycastHit hit;
        bool isHideInWalk = Physics.Raycast(transform.position + Vector3.up, direction, out hit, 1000);

        if (isHideInWalk)
        {
            if (hit.collider.CompareTag("Player"))
            {
                return false;
            }
        }
        return true;
    }
    public void Shooting()
    {
        if (!cooldown.IsCooldown(cooltimeName))
        {
            Debug.Log("½¸!!");

            cooldown.SetCooldown(cooltimeName, EnemySoData.weaponData.attackCoolTime);
            OnShooting?.Invoke();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawRay(transform.position + Vector3.up,transform.forward * EnemySoData.weaponData.shootDistance);
        Gizmos.color = Color.blue;
        //Gizmos.DrawRay(transform.position + Vector3.up, direction * 1000);
    }
}
