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
        public string name;
        public float health;
        public float speed;
        public int gold;

        public float size;
        public Color color;
    }

    public EnemyDataStruct[] enemyType = new EnemyDataStruct[1];
    public EnemyDataStruct[] enemyData = new EnemyDataStruct[1];

    public void SpawnEnemy(int type)
    {
        Enemy newEnemy = Instantiate(enemyPrefab, this.transform).GetComponent<Enemy>();
        newEnemy.startPoint = startPoint;
        newEnemy.waypoints = waypoints;

        newEnemy.gameObject.name = enemyData[type].name;
        newEnemy.health = enemyData[type].health;
        newEnemy.speed = enemyData[type].speed;
        newEnemy.gold = enemyData[type].gold;

        newEnemy.GetComponent<MeshRenderer>().material.color = enemyData[type].color;
        newEnemy.transform.localScale = Vector3.one* enemyData[type].size;

    }
}
