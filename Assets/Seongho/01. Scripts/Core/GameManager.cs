using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private PoolingList _poolingList;
    [SerializeField]
    private WeaponList weaponList;
    [SerializeField]
    private Transform _playerTrm;
    public Transform PlayerTrm => _playerTrm;

    public AgentHP PlayerHP{
        get{
            _playerHP ??= GameObject.FindGameObjectWithTag("Player").GetComponent<AgentHP>();
            return _playerHP;
        }
    }
    private AgentHP _playerHP;
    public GlowText GlowText{
        get{
            _glowText ??= GameObject.Find("GlowText").GetComponent<GlowText>();
            return _glowText;
        }
    }
    private GlowText _glowText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(this);
        DontDestroyOnLoad(this);
        CreatePool();
    }


    public void CreatePool()
    {
        PoolManager manager = new PoolManager(this.transform);
        TimeController controller = transform.AddComponent<TimeController>();

        foreach (PoolClass p in _poolingList.poolingList)
        {
            manager.CreatePool(p.poolObject, p.poolCount);
        }
    }
    public GunWeapon GetRandomWeightWeapon()
    {
        return weaponList.Weapons[GetRandomWeightWeaponIndex()].WeaponObject;
    }
    private int GetRandomWeightWeaponIndex()
    {
        float sum = 0;
        for (int i = 0; i < weaponList.Weapons.Count; i++)
        {
            sum += weaponList.Weapons[i].Weight;
        }
        float randomValue = Random.Range(0, sum);
        float tempSum = 0;
        for (int i = 0; i < weaponList.Weapons.Count; i++)
        {
            if (randomValue >= tempSum && randomValue < tempSum + weaponList.Weapons[i].Weight) return i;
            else tempSum += weaponList.Weapons[i].Weight;
        }
        return 0;
    }
}
