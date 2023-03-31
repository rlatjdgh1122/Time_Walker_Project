using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableMono : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Time.timeScale = 0.2f;
        }
        else if (Input.GetKeyUp(KeyCode.E))
            Time.timeScale = 1f;
    }}
