using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Bullet/BulletData")]
public class BulletDataSO : ScriptableObject
{
    public int damage;
    public float bulletSpeed;

    public GameObject impactObstaclePrefab;
    public GameObject impactEnemyPrefab;

    public float lifeTime;
}
