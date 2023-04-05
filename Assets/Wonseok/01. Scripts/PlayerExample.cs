using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExample : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField]
    private SavePoint savePoint;

    public float speed = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SavePoint"))
        {
            Debug.Log("!");
            SavePoint.Instance?.UpdateSpawnPoint();
            other.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        // 사용자 입력 받기
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 입력에 따라 캡슐 이동하기
        transform.position += new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;

        // 마우스 위치에 따라 캡슐 회전시키기
        if (Camera.main != null)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.transform.position.y - transform.position.y;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.y = transform.position.y;
            transform.LookAt(worldPos);
        }
    }
}
