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
    [SerializeField]
    private Image _slashImage;

    private void Awake() {
        Instance = this;
        agentSkill = FindObjectOfType<AgentSkill>();
    }

    void Update(){
        FillSizeCoolTime();
        FillSizeSlashCoolTime();
    }


    public void FillSizeCoolTime(){
        _coolImage.fillAmount = 1f - agentSkill.GetDashTimer();
    }
    public void FillSizeSlashCoolTime() {
        _slashImage.fillAmount = 1f - agentSkill.GetSlahTimer();
    }

}