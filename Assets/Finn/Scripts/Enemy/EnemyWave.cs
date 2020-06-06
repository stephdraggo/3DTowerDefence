using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    #region variables


    [Header("Enemy Wave")]
    public int currentWave;
    //array of enemies in each wave
    public int[][] wave = new int[3][];
    //wait between enemies in wave
    public float[] waitTime = new float[1];
    public bool inWave;

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
        public int damage;

        public float size;
        public Color color;
    }

    public EnemyDataStruct[] enemyData = new EnemyDataStruct[3];

    GameControl gameControl;

    #endregion

    #region start
    private void Start()
    {
        gameControl = GameObject.FindGameObjectWithTag("GameControl").GetComponent<GameControl>();

        //set up enemies
        enemyData = new EnemyDataStruct[4];
        enemyData[0] = new EnemyDataStruct { name = "normal", health = 10, speed = 5, gold = 10, damage = 2, size = 1, color = Color.red };
        enemyData[1] = new EnemyDataStruct { name = "fast", health = 5, speed = 10, gold = 5, damage = 1, size = 0.8f, color = Color.yellow };
        enemyData[2] = new EnemyDataStruct { name = "strong", health = 20, speed = 4, gold = 20, damage = 4, size = 1.5f, color = Color.blue };
        enemyData[3] = new EnemyDataStruct { name = "boss", health = 200, speed = 4, gold = 100, damage = 10, size = 2, color = Color.green };


        //set up waves
        currentWave = 1;
        wave = new int[11][];
        waitTime = new float[wave.Length];
        wave[0] = null;

        wave[1] = new int[3] { 0, 0, 0 };
        waitTime[1] = 1;

        wave[2] = new int[5] { 0, 0, 0, 0, 0 };
        waitTime[2] = 1;

        wave[3] = new int[5] { 1, 1, 1, 1, 1 };
        waitTime[3] = 0.8f;

        wave[4] = new int[6] { 0, 0, 0, 1, 1, 1 };
        waitTime[4] = 1;

        wave[5] = new int[5] { 0, 0, 0, 0, 2 };
        waitTime[5] = 1;

        wave[6] = new int[4] { 2, 2, 2, 2 };
        waitTime[6] = 1.1f;

        wave[7] = new int[9] { 0, 0, 0, 1, 1, 1, 2, 2, 2 };
        waitTime[7] = 1;

        wave[8] = new int[10] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        waitTime[8] = 0.4f;

        wave[9] = new int[8] { 2, 2, 2, 2, 2, 2, 2, 2 };
        waitTime[9] = 1.1f;

        wave[10] = new int[1] { 3 };
        waitTime[10] = 5f;

        gameControl.UpdateWaveText();

    }
    #endregion

    #region spawn enemy
    public void SpawnEnemy(int type)
    {
        Enemy newEnemy = Instantiate(enemyPrefab, this.transform).GetComponent<Enemy>();
        newEnemy.startPoint = startPoint;
        newEnemy.waypoints = waypoints;

        newEnemy.gameObject.name = enemyData[type].name;
        newEnemy.health = enemyData[type].health;
        newEnemy.speed = enemyData[type].speed;
        newEnemy.gold = enemyData[type].gold;
        newEnemy.damage = enemyData[type].damage;
        if (currentWave == wave.Length - 1)
        {
            newEnemy.finalEnemy = true;
        }

        newEnemy.GetComponent<MeshRenderer>().material.color = enemyData[type].color;
        newEnemy.transform.localScale = Vector3.one* enemyData[type].size;
    }
    #endregion

    #region wave

    public void StartWave()
    {
        if (currentWave < wave.Length)
        {
            if (!inWave)
            {
                inWave = true;
                StartCoroutine(RunWave());
            }
        }
    }
    public IEnumerator RunWave()
    {
        for (int i = 0; i < wave[currentWave].Length; i++)
        {
            SpawnEnemy(wave[currentWave][i]);
            yield return new WaitForSeconds(waitTime[currentWave]);
        }

        currentWave += 1;
        inWave = false;
        gameControl.UpdateWaveText();
        yield return null;
    }
    #endregion
}
