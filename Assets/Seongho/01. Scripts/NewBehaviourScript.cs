using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    RegularBullet regularBullet;
    public Transform firePos;
    private void Awake()
    {
        regularBullet = GameObject.Find("PistolBullet").GetComponent<RegularBullet>();
    }
    private void Start()
    {
        Vector3 randomPosition = firePos.position + firePos.forward + (Vector3)Random.insideUnitCircle * 2;
        for (int i = 0; i < 10000000; i++)
        {
            Vector3 a = firePos.position + firePos.forward + (Vector3)Random.insideUnitCircle * 2;
            Debug.Log(a);
        }
        Vector3 direction = (randomPosition - firePos.position);

        regularBullet.Init();
        regularBullet.SetPositionAndRotation(firePos.position,
            Quaternion.LookRotation(direction));
    }
}
