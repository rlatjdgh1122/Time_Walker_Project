using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExample : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField]
    private SavePoint savePoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SavePoint"))
        {
            Debug.Log("!");
            savePoint.UpdateSpawnPoint();
            other.gameObject.SetActive(false);
        }
    }
}
