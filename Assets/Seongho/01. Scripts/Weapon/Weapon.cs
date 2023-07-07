using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeaponable
{
    protected Animator animatorController;
    protected virtual void Awake()
    {
        animatorController = GameObject.Find("Model").GetComponent<Animator>();
    }
    public abstract void Shooting();    
    public abstract void StopShooting();

}
