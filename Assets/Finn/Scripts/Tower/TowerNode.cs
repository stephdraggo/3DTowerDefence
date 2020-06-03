using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerNode : MonoBehaviour
{

    [Header("Tower Prefab")]
    public GameObject TowerPrefab;

    [Header("Current Tower")]
    public Tower tower;

    GameControl gameControl;

    private void Start()
    {
        gameControl = GameObject.FindGameObjectWithTag("GameControl").GetComponent<GameControl>();
    }
    private void OnMouseDown()
    {
        gameControl.SelectNode(this);
    }

    public void BuildTower()
    {
        tower = GameObject.Instantiate(TowerPrefab, this.transform).GetComponent<Tower>();
    }
}
