using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    RegularBullet regularBullet;
    public GameObject gameObject;
    public Transform firePos;
    private void Awake()
    {
        regularBullet = GameObject.Find("PistolBullet").GetComponent<RegularBullet>();
    }
    private void Start()
    {
        Vector3 randomPosition = firePos.position + firePos.forward + (Vector3)Random.insideUnitCircle * 1;
        Vector3 direction = (randomPosition - firePos.position);

        regularBullet.Init();
        regularBullet.SetPositionAndRotation(firePos.position,
            Quaternion.LookRotation(direction));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomPosition = firePos.position + firePos.forward + (Vector3)Random.insideUnitCircle * 1;
            Vector3 direction = (randomPosition - firePos.position);

            regularBullet.Init();
            regularBullet.SetPositionAndRotation(firePos.position,
                Quaternion.LookRotation(direction));
        }
    }
}
