using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class bullet : MonoBehaviour
{
    public float speed = 10;

    private Vector3 pos;
    private void Start()
    {
        pos = transform.parent.forward;
    }
    private void Update()
    {
        transform.Translate(pos * speed * Time.deltaTime);
    }
}
