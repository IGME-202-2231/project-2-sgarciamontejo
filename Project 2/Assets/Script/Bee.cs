using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : Agent
{
    [SerializeField]
    float wanderTime = 1f;

    [SerializeField]
    float wanderRadius = 1f;

    [Min(1f)]
    public float stayInBoundsWeight = 50f;

    public float wanderWeight = 1f;


    [SerializeField]
    [Range(0.0f, 100.0f)]
    float avoidWeight = 1.0f;
    [SerializeField]
    float avoidTime = 2.0f;

    protected override void CalcSteeringForces()
    {
        totalForce += Wander(wanderTime, wanderRadius, wanderWeight);
        totalForce += StayInBounds(stayInBoundsWeight);
        totalForce += Separate();

        totalForce += AvoidBear(avoidTime) * avoidWeight;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, myPhysicsObject.radius);

        Vector3 futurePosition = CalcFuturePosition(avoidTime);
        float dist = Vector3.Distance(transform.position, futurePosition) + myPhysicsObject.radius;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, futurePosition);


        Vector3 wanderTarget = CalcFuturePosition(wanderTime);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(wanderTarget, wanderRadius);
        Gizmos.DrawLine(transform.position,wanderTarget);


        Vector3 boxSize = new Vector3(myPhysicsObject.radius * 6, dist, 0);
        Vector3 boxCenter = new Vector3(0, dist / 2, 0);

        Gizmos.color = Color.green;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(boxCenter, boxSize);

        Gizmos.matrix = Matrix4x4.identity;

        Gizmos.color = Color.red;
        foreach(Vector3 pos in foundObstacles)
        {
            Gizmos.DrawLine(transform.position, pos);
        }
    }
}
