using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "SO/GunSOData")]
public class GunSOData : ScriptableObject
{
    public GameObject bullet;
    [Range(0, 999)] public int ammoCapacity = 100;
    [Range(0.1f, 10)] public float weaponDelay = 0.1f;
    public float liveBulletTime = 1.5f;
    public bool autoFire;

}
