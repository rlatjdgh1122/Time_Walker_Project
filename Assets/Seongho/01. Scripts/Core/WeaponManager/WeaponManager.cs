using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour //���ιٲ� ���ȵ��� ����
{
    private Dictionary<string, Weapon> _weapons = new();
    public static WeaponManager Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(Instance);
    }
    public void CreateWeapon(string weaponName, Weapon weapon)
    {
        _weapons.Add(weaponName, weapon);
    }
    public Weapon SpawnWeapon(string weaponName)
    {
        if (_weapons.ContainsKey(weaponName) == false)
        {
            Debug.LogError("�ش��ϴ� ����� �������� �ʽ��ϴٶ���.");
            return null;
        }
        else
            return _weapons[weaponName];
    }
}