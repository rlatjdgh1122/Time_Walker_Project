using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Time.timeScale = 0.2f;
        }
        else if (Input.GetKeyUp(KeyCode.E))
            Time.timeScale = 1f;
    }
}
