using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deselect : MonoBehaviour
{
    GameControl gameControl;
    private void Start()
    {
        gameControl = GameObject.FindGameObjectWithTag("GameControl").GetComponent<GameControl>();
    }

    private void OnMouseDown()
    {
        gameControl.Deselect();
    }
}
