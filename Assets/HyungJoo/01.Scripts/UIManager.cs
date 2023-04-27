using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour{
    [HideInInspector]
    public UIManager Instance;
    [HideInInspector]
    public AgentSkill agentSkill;

    [SerializeField]
    private Image _coolImage;

    private void Awake() {
        Instance = this;
        agentSkill = FindObjectOfType<AgentSkill>();
    }

    void Update(){
        FillSizeCoolTime();
    }


    public void FillSizeCoolTime(){
        _coolImage.fillAmount = 1f - agentSkill.GetTimer();
    }

}