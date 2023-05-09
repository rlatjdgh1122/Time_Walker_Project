using DynamicMeshCutter;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TestSeonghoScript : MonoBehaviour
{
    private List<EnemyHit> gun;
    private void Awake()
    {
        gun = FindObjectsOfType<EnemyHit>().ToList();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            gun.ForEach(p => p.OnCut_Ver());
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            gun.ForEach(p => p.OnCut_Hor());
        }
    }
}
