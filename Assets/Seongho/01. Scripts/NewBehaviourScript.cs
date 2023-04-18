using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   public RegularBullet regularBullet;
    public Transform firePos;
    public float spreadAngle = 2;

    private void Start()
    {
        Vector3 randomPosition = firePos.position + firePos.right * 5 + Random.insideUnitSphere * spreadAngle;
        Vector3 direction = (randomPosition - firePos.position).normalized;
        float deree1 = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;


        float deree2 = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Debug.Log(deree1);
        regularBullet.Init();
        regularBullet.SetPositionAndRotation(firePos.position,
            Quaternion.Euler(0, deree1, deree2));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomPosition = firePos.position + firePos.right * 5 + Random.insideUnitSphere * spreadAngle;
            Vector3 direction = (randomPosition - firePos.position).normalized;
            float deree1 = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;


            float deree2 = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Debug.Log(deree1);
            regularBullet.Init();
            regularBullet.SetPositionAndRotation(firePos.position,
                Quaternion.Euler(0, deree1, deree2));
        }
    }
}
