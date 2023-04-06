using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    private GameObject Target;
    public GameObject target => Target;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(this);
    }
}
