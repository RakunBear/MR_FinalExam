using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWatPoint : MonoBehaviour
{
    public List<Transform> WaypointList;
    public float WalkDeltaTime = 0.02f;
    public float AvaibleDistance = 1.0f;
    public bool IsInfinity = true;
    public bool ComeBack = true;

    private Vector3 startPoint;   

    private void Start()
    {
        StartCoroutine(GoToWalk());
    }

    IEnumerator GoToWalk()
    {
        IEnumerator PlayWay()
        {
            foreach(var wayPoint in WaypointList)
            {
                yield return Walk(wayPoint.position);
            }

            if (ComeBack)
            {
                yield return Walk(startPoint);
            }
        }
    
        startPoint = transform.position;

        if (IsInfinity)
        {
            while(true)
            {
                yield return PlayWay();
            }
        }
        else
        {
            yield return PlayWay();
        }
        
    }

    private IEnumerator Walk(Vector3 wayPoint)
    {
        transform.LookAt(wayPoint);
        while (Vector3.Distance(transform.position, wayPoint) > AvaibleDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoint, WalkDeltaTime);
            yield return null;
        }
    }
}
