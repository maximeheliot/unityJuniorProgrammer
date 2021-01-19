using UnityEngine;
using UnityEngine.Profiling;

public class ShipController : MonoBehaviour
{
    private GameObject[] targets;

    private void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Target");
    }

    private void Update()
    {
        GameObject nearestTarget = null;

        var nearestDistance = float.MaxValue;

        foreach (var target in targets)
        {
            Profiler.BeginSample("DISTANCE");

            var currentDistance = Vector2.Distance(transform.position, target.transform.position);

            Profiler.EndSample();

            Profiler.BeginSample("SqrMAGNITUDE");

            var currentDistance2 = Vector2.SqrMagnitude(target.transform.position - transform.position);

            Profiler.EndSample();

            if (currentDistance < nearestDistance)
            {
                nearestDistance = currentDistance;
                nearestTarget = target;
            }
        }

        Debug.DrawLine(transform.position, nearestTarget.transform.position);
    }
}