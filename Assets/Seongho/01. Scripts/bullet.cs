using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 10;

    private void Update()
    {
        transform.Translate(transform.parent.forward * speed * Time.deltaTime);
    }
}
