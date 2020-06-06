using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public float health;
    public float speed;
    public int gold;
    public int damage;

    [Header("Path")]
    public Transform startPoint;
    public Transform[] waypoints;

    GameControl gameControl;

    //waypoint index
    int index = 0;

    //distance travelled, towers will target furthest enemy
    public float Distance { get; private set; }

    //damage that enemy will take when hit, for turning invisible if going to die
    public float incomingDamage = 0;
    //if invisible (towers won't target this enemy)
    public bool invisible;

    //if true, game ends after defeat
    public bool finalEnemy;


    #region start
    private void Start()
    {
        transform.position = startPoint.position;
        gameControl = GameObject.FindGameObjectWithTag("GameControl").GetComponent<GameControl>();
    }
    #endregion

    #region movement

    void Update()
    {
        Move();
    }

    void Move()
    {
        //move towards next waypoint and increase distance
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, speed * Time.deltaTime);
        Distance += speed * Time.deltaTime;

        //if at waypoint, increase index to next waypoint
        if (Vector3.Distance(transform.position, waypoints[index].position) < 0.1f)
        {
            index += 1;

            //if at final waypoint, dissappear
            if (index >= waypoints.Length)
            {
                gameControl.Damage(damage);
                GameObject.Destroy(this.gameObject);
                
            }
        }
    }
    #endregion

    #region damage and death
    public void Damage(float amount)
    {
        health -= amount;
        incomingDamage -= amount;
        if (health <= 0)
        {
            RemoveFromLists();
            gameControl.IncreaseGold(gold);
            if (finalEnemy)
            {
                gameControl.WinGame();
            }
            Destroy(this.gameObject);
        }
    }

    public void RemoveFromLists()
    {
        //find all towers and remove from target lists
        GameObject[] towerObjects = GameObject.FindGameObjectsWithTag("Tower");
        Tower[] towers = new Tower[towerObjects.Length];
        if (towerObjects.Length > 0)
        {
            for (int i = 0; i < towers.Length; i++)
            {
                towers[i] = towerObjects[i].GetComponent<Tower>();
            }

            foreach (Tower tower in towers)
            {
                if (tower.targets.Contains(this.gameObject))
                {
                    tower.targets.Remove(this.gameObject);
                }
            }
        }
        invisible = true;

        
    }
    #endregion

}
