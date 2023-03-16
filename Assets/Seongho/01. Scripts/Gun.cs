using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform gunPivot;
    void Update()
    {
        this.transform.position = gunPivot.position;
    }
}
