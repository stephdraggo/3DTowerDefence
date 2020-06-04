using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    [Header("Enemy Prefab")]
    public GameObject enemyPrefab;

    [Header("Path")]
    public Transform startPoint;
    public Transform[] waypoints;

    [System.Serializable]
    public struct EnemyDataStruct
    {
        float health;
        float speed;
        int gold;

        float size;
        Color color;
    }

    public EnemyDataStruct[] enemyType = new EnemyDataStruct[1];

    public void SpawnEnemy()
    {
        Enemy newEnemy = Instantiate(enemyPrefab, this.transform).GetComponent<Enemy>();
        newEnemy.startPoint = startPoint;
        newEnemy.waypoints = waypoints;

    }
}
