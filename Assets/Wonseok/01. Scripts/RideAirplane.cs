using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RideAirplane : MonoBehaviour
{
    [SerializeField]
    private GameObject plane;
    [SerializeField]
    private GameObject cameraObj;
    [SerializeField]
    private GameObject sword;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FowardAirplane();
            Debug.Log("Go Airplane!");
        }
    }

    public void FowardAirplane()
    {
        sword.transform.DOLocalMove(new Vector3(-0.31f, -1.81f, -0.26f), 0.1f);
        cameraObj.transform.DOLocalMove(new Vector3(-0.119f, 2f, -3.4f), 2f);
        plane.transform.DOMove(new Vector3(101.3f, -0.13f, -173f), 35f);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        if (Input.GetKeyDown(KeyCode.E))
    //        {
    //            Debug.Log("Go Airplane!");
    //            //로직 시작
    //        }
    //    }
    //}
}
