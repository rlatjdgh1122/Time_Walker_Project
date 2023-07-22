using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using UnityEngine.SceneManagement;
public enum UIState
{
    None = 0,
    UI = 1,
}


public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(UIManager)) as UIManager;
            }
            return _instance;
        }
    }
    private UIState _currentState;
    public UIState CurrentState => _currentState;

    [SerializeField] private GameObject _uiPanel;
    private Vector3 _originScale;
    private Button _continueBtn;
    private Button _exitBtn;

    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        _uiPanel.transform.Find("ContinueBtn").GetComponent<Button>().onClick.AddListener(()=>UnShowPanel());
        _uiPanel.transform.Find("ExitBtn").GetComponent<Button>().onClick.AddListener(() => GoToMain());
        _uiPanel.transform.Find("ExitBtn").GetComponent<Button>().onClick.AddListener(() => UnShowPanel());

        _uiPanel.SetActive(false);

        _originScale = _uiPanel.transform.localScale;
    }

    private void GoToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowPanel()
    {
        _uiPanel.SetActive(true);
        Time.timeScale = 0f;
        UpdateState(UIState.UI);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UnShowPanel()
    {
        Time.timeScale = 1f;
        _uiPanel.SetActive(false);
        UpdateState(UIState.None);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UpdateState(UIState state)
    {
        _currentState = state;
    }
}
