using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public int gold;
    public TowerNode selectedNode;
    public GameObject rangeSphere;
    private void Start()
    {
        //hide selection
        GetComponent<MeshRenderer>().enabled = false;
        rangeSphere.GetComponent<MeshRenderer>().enabled = false;
    }

    #region selection
    public void SelectNode(TowerNode node)
    {
        selectedNode = node;

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

    #region towers
    public void BuildTower()
    {
        if (selectedNode != null)
        {
            if (selectedNode.tower == null)
            {
                selectedNode.BuildTower();
            }
        }
    }
    #endregion
}
