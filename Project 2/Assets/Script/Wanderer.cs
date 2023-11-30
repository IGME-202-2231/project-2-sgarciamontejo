using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Agent
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

    float avoidTime = 2.0f;

    protected override void CalcSteeringForces()
    {
        myPhysicsObject.ApplyForce(Wander(wanderTime, wanderRadius, wanderWeight));
        myPhysicsObject.ApplyForce(StayInBounds(stayInBoundsWeight));
        myPhysicsObject.ApplyForce(Separate());

        myPhysicsObject.ApplyForce(AvoidObstacles(avoidTime) * avoidWeight);
    }

    private void OnDrawGizmosSelected()
    {
        /*Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(CalcFuturePosition(wanderTime), wanderRadius);
        Gizmos.DrawLine(transform.position, wandertarget);*/

        Vector3 futurePosition = CalcFuturePosition(avoidTime);
        float dist = Vector3.Distance(transform.position, futurePosition) + myPhysicsObject.radius;


        Vector3 boxSize = new Vector3(myPhysicsObject.radius * 2, dist, myPhysicsObject.radius * 2);
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
