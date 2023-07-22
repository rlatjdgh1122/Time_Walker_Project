using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class portal : MonoBehaviour
{
    public UnityEvent OnEnterPortal;
    [SerializeField] private LayerMask _WhatIsPlayer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeNextSceen() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    public void ChangeSceenAsName(string name) => SceneManager.LoadScene(name);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _WhatIsPlayer)
            OnEnterPortal?.Invoke();
    }
}
