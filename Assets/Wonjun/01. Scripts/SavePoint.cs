using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigid;
    private Vector3 spotPos;
    Renderer _rd;

    void Awake()
    {
        _rd = gameObject.GetComponent<Renderer>();
    }
    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Debug.Log("ºÎµ÷È÷±â!!!!!!!!!");
            _rd.material.color = Color.blue;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _rd.material.color = Color.white;
    }
}
