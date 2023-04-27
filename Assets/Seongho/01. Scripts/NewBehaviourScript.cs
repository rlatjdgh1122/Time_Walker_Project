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
        }
    }
}
