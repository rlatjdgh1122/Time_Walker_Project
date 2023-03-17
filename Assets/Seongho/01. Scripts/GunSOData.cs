using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO/GunSOData")]
public class GunSOData : ScriptableObject
{
    [SerializeField] private GameObject bullet;
    [Range(0, 999)] public int ammoCapacity = 100;
    [Range(0.1f, 2)] public float weaponDelay = 0.1f;
    public bool autoFire;
}
