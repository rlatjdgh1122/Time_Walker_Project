using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class AgentHP : MonoBehaviour{
    [SerializeField]
    private HPSO _hpSO;

    public int CurrentHP => _currentHP;
    private int _currentHP;
    

    public UnityEvent<float> OnDamaged;
    public UnityEvent OnDead;

    private void Awake() {
        _currentHP = _hpSO.maxHP;
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.T)){
            Damaged(1);
        }    
    }

    public void Damaged(int damage){
        _currentHP -= damage;
        _currentHP = Mathf.Clamp(_currentHP,0 ,_hpSO.maxHP);
        OnDamaged?.Invoke((float)_currentHP / _hpSO.maxHP);
        if(_currentHP == 0){
            DestroyProcess();
        }
    }

    private void DestroyProcess(){
        Destroy(this.gameObject);
        OnDead?.Invoke();
    }
}