using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    [Header("Control")]
    public int gold;
    public int towerCost = 100;
    public TowerNode selectedNode;
    public GameObject rangeSphere;

    [Header("UI References")]
    public Text goldText;
    public Text buildText;
    public Text rangeText;
    public Text damageText;
    public Text speedText;
    
    #region start
    private void Start()
    {
        //set default gold
        gold = 200;
        UpdateGoldText();
        UpdateButtonText();

        //hide selection
        GetComponent<MeshRenderer>().enabled = false;
        rangeSphere.GetComponent<MeshRenderer>().enabled = false;
    }
    #endregion

    #region selection
    public void SelectNode(TowerNode node)
    {
        selectedNode = node;
        UpdateButtonText();

        //show selection
        GetComponent<MeshRenderer>().enabled = true;
        transform.position = node.transform.position;
        transform.position += new Vector3(0, 5, 0);

        //Radius circle, maybe add in once towers have models
        /*
        if (selectedNode.tower != null)
        {
            rangeSphere.GetComponent<MeshRenderer>().enabled = true;
            rangeSphere.transform.position = node.tower.transform.position;
            rangeSphere.transform.parent = node.tower.transform;

            //rangeSphere.transform.localScale = Vector3.one

            //rangeSphere.transform.localScale *= node.tower.range;
        }
        */
    }

    public void Deselect()
    {
        selectedNode = null;
        GetComponent<MeshRenderer>().enabled = false;
        rangeSphere.GetComponent<MeshRenderer>().enabled = false;
    }
    #endregion

    #region towers
    public void BuildTower()
    {
        if (selectedNode != null)
        {
            if (selectedNode.tower == null)
            {
                if (gold >= towerCost)
                {
                    gold -= towerCost;
                    UpdateGoldText();
                    selectedNode.BuildTower();
                    UpdateButtonText();
                }
            }
        }
    }

    public void UpgradeRange()
    {
        if (selectedNode != null)
        {
            if (selectedNode.tower != null)
            {
                if (gold >= selectedNode.tower.rangeCost)
                {
                    gold -= selectedNode.tower.rangeCost;
                    UpdateGoldText();
                    selectedNode.tower.UpgradeRange();
                    UpdateButtonText();
                }
            }
        }
    }

    public void UpgradeDamage()
    {
        if (selectedNode != null)
        {
            if (selectedNode.tower != null)
            {
                if (gold >= selectedNode.tower.damageCost)
                {
                    gold -= selectedNode.tower.damageCost;
                    UpdateGoldText();
                    selectedNode.tower.UpgradeDamage();
                    UpdateButtonText();
                }
            }
        }
    }

    public void UpgradeSpeed()
    {
        if (selectedNode != null)
        {
            if (selectedNode.tower != null)
            {
                if (gold >= selectedNode.tower.speedCost)
                {
                    gold -= selectedNode.tower.speedCost;
                    UpdateGoldText();
                    selectedNode.tower.UpgradeSpeed();
                    UpdateButtonText();
                }
            }
        }
    }
    #endregion

    #region gold
    public void IncreaseGold(int amount)
    {
        //called by enemies when they die
        gold += amount;
        UpdateGoldText();
    }

    #endregion

    #region UI

    public void UpdateGoldText()
    {
        goldText.text = "Gold: " + gold;
    }

    public void UpdateButtonText()
    {
        if (selectedNode == null)
        {
            buildText.text = "-";
            rangeText.text = "-";
            damageText.text = "-";
            speedText.text = "-";
        }
        else if (selectedNode.tower == null)
        {
            buildText.text = "Build Tower (100G)";
            rangeText.text = "-";
            damageText.text = "-";
            speedText.text = "-";
        }
        else
        {
            buildText.text = "-";
            rangeText.text = "Upgrade Range (" + selectedNode.tower.rangeCost + "G)";
            damageText.text = "Upgrade Damage (" + selectedNode.tower.damageCost+ "G)";
            speedText.text = "Upgrade Speed (" + selectedNode.tower.speedCost + "G)";
        }
    }

    #endregion

}
