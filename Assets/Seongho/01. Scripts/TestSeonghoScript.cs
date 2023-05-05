using DynamicMeshCutter;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestSeonghoScript : MonoBehaviour
{
    public EnemyHit gun;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gun?.OnHit();
        }
    }
}
