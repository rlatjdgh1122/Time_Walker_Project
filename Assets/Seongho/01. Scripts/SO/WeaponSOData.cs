using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/WeaponData")]
public class WeaponSOData : ScriptableObject
{
    public string WeaponName;
    public string SoundName;

    [Range(1, 5f)]
    public float attackDelay;
    //public float motionDelay;
    [Range(1, 5f)]
    public float weaponDelay;
    [Range(0, 1f)]
    public float spreadAngle;

    public int bulletCount;

    public AnimatorOverrideController animatiorController;
}
