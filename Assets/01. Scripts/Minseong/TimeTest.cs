using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTest : MonoBehaviour
{
    
    void Update()
    {
        if (transform.position.x < 10)
        {
            transform.position += new Vector3(5 * Time.deltaTime, 0);
        }
        else
        {
            transform.position += new Vector3(-5 * Time.deltaTime, 0);
        }
    }
}
