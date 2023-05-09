using System.Transactions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIDashBoard : MonoBehaviour{
    [HideInInspector]
    public UIDashBoard Instance;
    [HideInInspector]
    public AgentSkill agentSkill;

    private Image _coolImage;
    private Image _dashImage;

    private void Awake() {
        Instance = this;
        agentSkill = FindObjectOfType<AgentSkill>();

        _coolImage = transform.Find("Dash").GetComponent<Image>();
        _dashImage = transform.Find("Slash").GetComponent<Image>();
    }

    void Update(){
        FillSizeCoolTime();
        FillSizeDashCoolTime();
    }

    public void FillSizeCoolTime(){
        _coolImage.fillAmount = 1f - agentSkill.GetTimer();
    }
    public void FillSizeDashCoolTime(){
        Debug.Log(1f - agentSkill.GetSlashTimer());
        _dashImage.fillAmount = 1f - agentSkill.GetSlashTimer();
    }
}