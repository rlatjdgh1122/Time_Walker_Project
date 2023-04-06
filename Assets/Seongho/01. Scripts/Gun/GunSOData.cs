using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/GunSOData")]
public class GunSOData : ScriptableObject
{
    public GameObject bullet;
    [Range(0, 999)] public int ammoCapacity = 100;
    public float liveBulletTime = 1.5f;

}
