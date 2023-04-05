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
        // ����� �Է� �ޱ�
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �Է¿� ���� ĸ�� �̵��ϱ�
        transform.position += new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;
    }
}
