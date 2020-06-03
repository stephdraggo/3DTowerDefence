using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    //for drawing gizmos in the scene view, won't show in game
    public Color gizmoColor = Color.white;
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
