using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public int gold;
    public TowerNode selectedNode;


    private void Start()
    {
        //hide selection
        GetComponent<MeshRenderer>().enabled = false;
    }

    #region selection
    public void SelectNode(TowerNode node)
    {
        selectedNode = node;
        //show selection and move above node
        GetComponent<MeshRenderer>().enabled = true;
        transform.position = node.transform.position;
        transform.position += new Vector3(0, 5, 0);
    }

    public void Deselect()
    {
        selectedNode = null;
        GetComponent<MeshRenderer>().enabled = false;
    }
    #endregion

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
