using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    RegularBullet regularBullet;
    public RegularBullet gameObject;
    public Transform firePos;
    public float spreadAngle;

    private void Awake()
    {
        regularBullet = GameObject.Find("PistolBullet").GetComponent<RegularBullet>();
    }
    private void Start()
    {
        Vector3 randomPosition = firePos.forward
            * 5 + Random.insideUnitSphere * spreadAngle; //이부분 수정필요

        float degreeY = Mathf.Atan2(randomPosition.z, firePos.position.x) * Mathf.Rad2Deg;
        float degreeZ = Mathf.Atan2(randomPosition.y, firePos.position.x) * Mathf.Rad2Deg;

        gameObject.SetPositionAndRotation(firePos.position, Quaternion.Euler(0, degreeY, degreeZ));
        gameObject.isEnemy = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomPosition = firePos.forward * 10
            + Random.insideUnitSphere * spreadAngle; //이부분 수정필요
            float degreeY = Mathf.Atan2(randomPosition.z, firePos.position.x) * Mathf.Rad2Deg;
            float degreeZ = Mathf.Atan2(randomPosition.y, firePos.position.x) * Mathf.Rad2Deg;

            gameObject.SetPositionAndRotation(firePos.position, Quaternion.Euler(0, degreeY, degreeZ));
            gameObject.isEnemy = false;
        }
    }
}
