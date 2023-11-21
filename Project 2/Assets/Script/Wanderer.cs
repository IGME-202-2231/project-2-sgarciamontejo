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

    protected override void CalcSteeringForces()
    {
        myPhysicsObject.ApplyForce(Wander(wanderTime, wanderRadius, wanderWeight));
        myPhysicsObject.ApplyForce(StayInBounds(stayInBoundsWeight));
        myPhysicsObject.ApplyForce(Separate());
    }
}
