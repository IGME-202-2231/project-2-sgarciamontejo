using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] PhysicsObject fleer;
    [SerializeField] PhysicsObject seeker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(collision(fleer, seeker))
        {
            float x = Random.Range(-fleer.width, fleer.width); //camera sizes not sprite sizes
            float y = Random.Range(-fleer.height, fleer.height);
            fleer.Position = new Vector3(x, y, 0);
        }
    }

    bool collision(PhysicsObject fleer, PhysicsObject seeker)
    {
        double distance = Mathf.Sqrt(Mathf.Pow((seeker.Position.x - fleer.Position.x), 2) + Mathf.Pow((seeker.Position.y - fleer.Position.y), 2));
        if (distance < (fleer.radius + seeker.radius))
        {
            return true;
        }
        return false;
    }
}
