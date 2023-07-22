using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class AgentHP : MonoBehaviour,IDamagable{
    [SerializeField]
    private HPSO _hpSO;

    public int CurrentHP => _currentHP;
    private int _currentHP;
    protected AgentAnimator _agentAnimator;

    public UnityEvent<float> OnDamaged;
    public UnityEvent OnDead;

    private void Awake() {
        _currentHP = _hpSO.maxHP;
        _agentAnimator = GetComponent<AgentAnimator>();
        _agentAnimator.OnDeadAnimationTrigger += RestartScene;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.T)){
            Damaged(100);
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

    public void RestartScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void DestroyProcess(){
        Debug.Log("DestroyProcess");
        _agentAnimator.Dead();
        //Destroy(this.gameObject);
        OnDead?.Invoke();
    }
}