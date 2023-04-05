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

    private int num = 0; //스폰포인트 세는 용도

    void Awake()
    {
        Instance = this;

        spawnPoint = player.transform.position; //첫 스폰포인트 설정(플레이어 첫 생성위치)
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
        num++; //한번 업데이트 될 때 +1
    }

    public void Respawn()
    {
        Debug.Log("Spawned");
        player.transform.position = new Vector3(spawnPoint.x, playerHeight, spawnPoint.z); //스폰포인트에 스폰 하는데 y값은 플레이어의 높이로 함
    }
}
