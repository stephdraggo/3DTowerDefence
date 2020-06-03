using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed;
    public float damage;
    public Enemy target;

    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
            {
                target.Damage(damage);
                Destroy(this.gameObject);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetTarget(GameObject enemy)
    {
        if (enemy.GetComponent<Enemy>())
        {
            target = enemy.GetComponent<Enemy>();
        }
        else
        {
            Debug.Log("Could not find enemy script on target");
        }
    }
}
