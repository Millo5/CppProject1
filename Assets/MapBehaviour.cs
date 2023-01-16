using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class MapBehaviour : MonoBehaviour
{

    [SerializeField] private MapSpot[] _route;
    public MapSpot[] Route => _route;

    public void OnDrawGizmos()
    {
        if (_route.Length < 2) return;

        for (int i = 0; i < _route.Length-1; i++)
        {
            Gizmos.color = new Color(255, 255, 0);
            DrawArrow(_route[i].transform.position, _route[i + 1].transform.position);
        }
        DrawArrow(_route[_route.Length-1].transform.position, _route[0].transform.position);
    }
    
    public static void DrawArrow(Vector3 a, Vector3 b)
    {
        Gizmos.DrawLine(a, b);

        Vector3 arrowHead = b - a;
        Vector3 arrowHeadNormal = Vector3.Cross(arrowHead, arrowHead.normalized).normalized;
        Vector3 arrowHeadDirection = Vector3.Cross(arrowHeadNormal, arrowHead).normalized;

        Vector3 arrowHead1 = b - (arrowHeadDirection * 0.25f + arrowHeadNormal * 0.1f) * arrowHead.magnitude;
        Vector3 arrowHead2 = b - (arrowHeadDirection * 0.25f - arrowHeadNormal * 0.1f) * arrowHead.magnitude;

        Gizmos.DrawLine(b, arrowHead1);
        Gizmos.DrawLine(b, arrowHead2);
    }

}
