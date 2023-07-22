using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class portal : MonoBehaviour
{
    public UnityEvent OnEnterPortal;
    [SerializeField] private LayerMask _WhatIsPlayer;
    [SerializeField] private Transform playerTRrm;
    void Start()
    {
        // playerTRrm = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(transform.position, playerTRrm.transform.position) < 3)
        {
            Debug.Log("포탈 작동");
            OnEnterPortal?.Invoke();
        }
    }

    public void ChangeNextSceen() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    public void ReloadSceen() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void ChangeSceenAsName(string name) => SceneManager.LoadScene(name);

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.layer == _WhatIsPlayer)
    //     {
    //         OnEnterPortal?.Invoke();
    //         Debug.Log("playerHit");
    //     }
    // }

    // private void OnCollisionEnter(Collider other)
    // {
    //     if (other.gameObject.layer == _WhatIsPlayer)
    //     {
    //         OnEnterPortal?.Invoke();
    //         Debug.Log("playerHit");
    //     }
    // }
}
