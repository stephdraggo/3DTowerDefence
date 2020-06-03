using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGizmo : MonoBehaviour
{
    //for drawing lines from waypoint to waypoint in scene view, won't show in game
    public Color gizmoColor = Color.white;
    public Transform[] path;
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        if (path.Length > 1)
        {
            for (int i = 0; i < path.Length - 1; i++)
            {
                Gizmos.DrawLine(path[i].position, path[i + 1].position);
            }
        }
    }
}
