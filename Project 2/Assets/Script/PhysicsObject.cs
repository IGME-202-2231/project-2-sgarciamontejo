using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    public Vector3 Position;
    Vector3 Direction;
    public Vector3 Velocity;
    Vector3 Acceleration;
    [SerializeField] float Mass;

    [SerializeField] bool Friction; //call ApplyFriction() if true
    [SerializeField] float Friction_coefficient;
    [SerializeField] bool Gravity;
    [SerializeField] bool bounce;
    float Gravity_strength = .1f;
    public float Maximum_speed = 2;

    public float height;
    public float width;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize * 2f;
        width = height * Camera.main.aspect;
        //radius = (transform.GetComponent<SpriteRenderer>().sprite.texture.width/2) * transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(Gravity)
        {
            ApplyGravity(Vector3.down * Gravity_strength);
        }
        if (Friction)
        {
            ApplyFriction(Friction_coefficient);
        }

        Velocity += Acceleration * Time.deltaTime;
        Velocity = Vector3.ClampMagnitude(Velocity, Maximum_speed);
        Velocity.z = 0;

        Position += Velocity * Time.deltaTime;

        Direction = Velocity.normalized;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Direction);

        transform.position = Position;

        Acceleration = Vector3.zero;
        if(bounce)
        {
            Bounce();
        }
    }

    void ApplyFriction(float coeff) //slides
    {
        Vector3 friction = Velocity * -1;
        friction.Normalize();
        friction = friction * coeff;
        ApplyForce(friction);
    }

    public void ApplyGravity(Vector3 force) //slides
    {
        Acceleration += force;
    }

    public void ApplyForce(Vector3 force) //slides
    {
        Acceleration += force / Mass;
    }

    void Bounce() //nature of code
    {
        if (Position.x > width/2)
        {
            Position.x = width/2;
            Velocity.x *= -1;
        }
        else if (Position.x < -width/2)
        {
            Position.x = -width/2;
            Velocity.x *= -1;
        }

        if (Position.y > height/2)
        {
            Position.y = height/2;
            Velocity.y *= -1;
        }
        else if(Position.y < -height/2)
        {
            Position.y = -height / 2;
            Velocity.y *= -1;
        }
    }

    public void ZeroVelocity()
    {
        Acceleration = Vector3.zero;
        Velocity = Vector3.zero;
    }
}
