using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public static SavePoint Instance;

    [Header("Transforms")]
    [SerializeField]
    private Vector3 spawnPoint;
    [SerializeField]
    private Transform[] spawnPointObj;

    [Header("PlayerInform")]
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float playerHeight = 1f;

    private int num = 0; //��������Ʈ ���� �뵵

    void Awake()
    {
        Instance = this;

        spawnPoint = player.transform.position; //ù ��������Ʈ ����(�÷��̾� ù ������ġ)
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Respawn();
        }
    }

    public void UpdateSpawnPoint()
    {       
        spawnPoint = spawnPointObj[num].transform.position;
        num++; //�ѹ� ������Ʈ �� �� +1
    }

    public void Respawn()
    {
        Debug.Log("Spawned");
        player.transform.position = new Vector3(spawnPoint.x, playerHeight, spawnPoint.z); //��������Ʈ�� ���� �ϴµ� y���� �÷��̾��� ���̷� ��
    }
}
