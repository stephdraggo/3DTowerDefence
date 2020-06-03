using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Shot Prefab")]
    public GameObject shot;
    public float shotSpeed;

    [Header("Stats")]
    public float range;
    public float damage;
    public float speed;

    [Header("Target enemies")]
    public List<GameObject> targets = new List<GameObject>();

    float reloadTime;

    private void Start()
    {
        //set up the sphere collider for finding enemies
        SphereCollider sphere = gameObject.AddComponent<SphereCollider>();
        sphere.radius = range;
        sphere.isTrigger = true;

        //start firing
        StartCoroutine(FireRoutine());
    }

    #region fire
    public void Fire(GameObject target)
    {
        //create the shot
        Shot newShot = Instantiate(shot, transform.position, Quaternion.identity).GetComponent<Shot>();

        //set the shots target and damage
        newShot.SetTarget(target);
        newShot.damage = damage;
        newShot.speed = shotSpeed;

        //increase enemies incoming damage and remove it from targets if it will die
        Enemy targetEnemy = target.GetComponent<Enemy>();
        targetEnemy.incomingDamage += damage;
        if (targetEnemy.health <= targetEnemy.incomingDamage)
        {
            targetEnemy.RemoveFromLists();
        }

        //set time for reloading
        reloadTime = Time.time;
    }

    public IEnumerator FireRoutine()
    {
        //set reload time based on speed
        float reload = 3 / speed;

        //wait until reloaded and target in sight
        yield return new WaitUntil(() => (Time.time >= reloadTime + reload));
        yield return new WaitUntil(() => (targets.Count > 0));

        //set time of shot for next reload
        reloadTime = Time.time;

        //find furthest enemy target and fire
        GameObject currentTarget = FindTarget();
        if (currentTarget != null)
        {
            Fire(currentTarget);
        }

        //restart routine to fire again
        StartCoroutine(FireRoutine());
        yield return null;
    }

    #endregion

    #region find target
    GameObject FindTarget()
    {
        //if there are targets in range, find the one with the highest distance and return it
        if (targets.Count > 0)
        {
            Enemy target = targets[0].GetComponent<Enemy>();
            if (targets.Count > 1)
            {
                for (int i = 1; i < targets.Count; i++)
                {
                    if (targets[i].GetComponent<Enemy>().Distance > target.Distance)
                    {
                        target = targets[i].GetComponent<Enemy>();
                    }
                }
            }
            return target.gameObject;
        }
        return null;
    }
    #endregion

    #region trigger enter/exit
    //when enemy enters range, add to targets list
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.GetComponent<Enemy>())
            {
                if (other.GetComponent<Enemy>().invisible == false)
                {
                    targets.Add(other.gameObject);
                }
            }
        }

    }
    //remove enemy from list when exiting range
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (targets.Contains(other.gameObject))
            {
                targets.Remove(other.gameObject);
            }
        }
    }
    #endregion


}
