using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    [SerializeField]
    protected PhysicsObject myPhysicsObject;
    [SerializeField]
    bool agentType; //true = Bee | false == Bear

    [SerializeField]
    protected float maxForce = 5;

    float wanderAngle;
    float perlinOffset;

    [SerializeField]
    float separationRange = 2f;

    protected AgentManager agentManager;
    List<Agent> agents;
    public AgentManager AgentManager { set { agentManager = value; } }

    // Start is called before the first frame update
    void Start()
    {
        wanderAngle = Random.Range(0, Mathf.PI * 2);
        perlinOffset = Random.Range(0, 10000);

        if(agentType)
        {
            agents = agentManager.Bees;
        }
        else
        {
            agents = agentManager
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalcSteeringForces();
    }

    protected abstract void CalcSteeringForces();

    protected Vector3 Seek(Vector3 targetpos, float weight = 1f)
    {
        Vector3 desiredVelocity = targetpos - transform.position;
        desiredVelocity = desiredVelocity.normalized * myPhysicsObject.Maximum_speed;
        Vector3 steeringForce = desiredVelocity - myPhysicsObject.Velocity;
        steeringForce = Vector3.ClampMagnitude(steeringForce, maxForce);
        return steeringForce * weight;
    }

    protected Vector3 Seek(GameObject target)
    {
        return Seek(target.transform.position);
    }

    protected Vector3 Flee(Vector3 targetpos)
    {
        Vector3 desiredVelocity = transform.position - targetpos;
        desiredVelocity = desiredVelocity.normalized * myPhysicsObject.Maximum_speed;

        Vector3 steeringForce = desiredVelocity - myPhysicsObject.Velocity;
        steeringForce = Vector3.ClampMagnitude(steeringForce, maxForce);
        return steeringForce;
    }

    protected Vector3 Flee(GameObject target)
    {
        return Flee(target.transform.position);
    }

    protected Vector3 StayInBounds(float weight = 1f)
    {
        Vector3 futurePosition = CalcFuturePosition();
        if(futurePosition.x > myPhysicsObject.width/2 ||
           futurePosition.x < -myPhysicsObject.width/2 ||
           futurePosition.y > myPhysicsObject.height/2 ||
           futurePosition.y < - myPhysicsObject.height/2)
        {
            return Seek(Vector3.zero, weight);
        }
        return Vector3.zero;
    }

    protected Vector3 Wander(float time, float radius, float weight = 1f)
    {
        Vector3 futurePos = CalcFuturePosition(time);

        //float randAngle = Random.Range(0.0f, Mathf.PI * 2);
        wanderAngle += (0.5f -(Mathf.PerlinNoise(
            transform.position.x * 0.1f + perlinOffset, 
            transform.position.y * 0.1f + perlinOffset)))
            * Mathf.PI * Time.deltaTime;

        Vector3 targetPos = new Vector3(
            Mathf.Cos(wanderAngle) * radius,
            Mathf.Sin(wanderAngle) * radius
        );

        //wanderTarget = futurePos + targetPos;

        return Seek(futurePos + targetPos, weight);
    }

    protected Vector3 CalcFuturePosition(float timeToLookAhead = 1f)
    {
        return transform.position + myPhysicsObject.Velocity * timeToLookAhead;
    }

    protected Vector3 Separate()
    {
        Vector3 separateForce = Vector3.zero;
        foreach(Agent a in agentManager.Agents)
        {
            if(a == this) { continue; }

            float distance = Vector3.Distance(transform.position, a.transform.position);
            distance += 0.000001f;

            /*if(distance < Mathf.Epsilon) // == 0  |  epsilon is smallest float point value | Mathf.Approximate
            {

            }*/

            separateForce += Flee(a.transform.position) * (separationRange / distance);
        }

        return separateForce;
    }

    protected Agent FindClosest()
    {
        float minDist = Mathf.Infinity;
        Agent nearest = null;

        foreach(Agent a in agentManager.Agents)
        {
            if(a == this) { continue; } //ignore self

            float dist = Vector2.Distance(transform.position, a.transform.position);

            if (dist < minDist)
            {
                minDist = dist; 
                nearest = a;
            }
        }

        return nearest;
    }
}
