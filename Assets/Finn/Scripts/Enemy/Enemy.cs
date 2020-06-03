using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public float health;
    public float speed;

    [Header("Path")]
    public Transform startPoint;
    public Transform[] waypoints;

    //waypoint index
    int index = 0;

    //distance travelled, towers will target furthest enemy
    public float Distance { get; private set; }

    private void Start()
    {
        transform.position = startPoint.position;
    }

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
                GameObject.Destroy(this.gameObject);
                //TODO: Player loses life
            }
        }
    }

}
