using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GunWeapon gun;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gun?.Shoot();
            /*Vector3 randomPosition = firePos.position + firePos.forward * 10
            + Random.insideUnitSphere * spreadAngle; //이부분 수정필요 firepos기준으로 앞방향이여야 함

            Debug.Log(randomPosition);

            float degreeY = Mathf.Atan2(randomPosition.z, firePos.position.x) * Mathf.Rad2Deg;
            float degreeZ = Mathf.Atan2(randomPosition.y, firePos.position.x) * Mathf.Rad2Deg;

            gameObject.SetPositionAndRotation(firePos.position, Quaternion.Euler(0, degreeY, degreeZ));*/
        }
    }
}
