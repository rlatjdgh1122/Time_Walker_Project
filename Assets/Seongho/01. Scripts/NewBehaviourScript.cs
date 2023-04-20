using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public RegularBullet gameObject;
    public Transform firePos;
    public float spreadAngle;
    private void Update()
    {
        Debug.Log(firePos.right);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomPosition = -firePos.right * 10
            + Random.insideUnitSphere * spreadAngle; //이부분 수정필요
            float degreeY = Mathf.Atan2(randomPosition.z, firePos.position.x) * Mathf.Rad2Deg;
            float degreeZ = Mathf.Atan2(randomPosition.y, firePos.position.x) * Mathf.Rad2Deg;

            gameObject.SetPositionAndRotation(firePos.position, Quaternion.Euler(0, degreeY, degreeZ));
            gameObject.isEnemy = false;
        }
    }
}
