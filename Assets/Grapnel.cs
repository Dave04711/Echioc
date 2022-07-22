using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapnel : MonoBehaviour
{
    [SerializeField] List<Route> routes = new List<Route>();
    Route currentRoute;
    Transform target;
    [SerializeField] Transform tip;
    [SerializeField] float speed = 1;
    public static Transform Tip;

    private void Start()
    {
        Tip = tip;
    }

    public void Init()
    {
        currentRoute = routes[Random.Range(0, routes.Count)];
        if (Random.value > .5f)
        {
            currentRoute.SwapPoints();
        }
        tip.position = currentRoute.pointA.position;
        target = currentRoute.pointB;
    }

    private void Update()
    {
        if (Vector3.Distance(tip.position, currentRoute.pointA.position) <= .02f) { target = currentRoute.pointB; }
        if (Vector3.Distance(tip.position, currentRoute.pointB.position) <= .02f) { target = currentRoute.pointA; }

        tip.position = Vector3.MoveTowards(tip.position, target.position, speed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        foreach (var route in routes)
        {
            Gizmos.DrawLine(route.pointA.position, route.pointB.position);
        }
    }
}
[System.Serializable]
public class Route
{
    public Transform pointA, pointB;
    public void SwapPoints()
    {
        var tmp = pointA;
        pointA = pointB;
        pointB = tmp;
    }
}