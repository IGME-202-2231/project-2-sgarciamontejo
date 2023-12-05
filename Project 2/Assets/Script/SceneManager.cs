using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneManager : MonoBehaviour
{
    //[SerializeField] List<PhysicsObject> objects;
    [SerializeField]
    AgentManager agentManager;

    [SerializeField]
    Obstacle bearPrefab;

    Vector3 mousePos;

    float cooldown = 2f;
    float cooldownTimestamp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0;

        /*foreach(PhysicsObject obj in objects)
        {
            Vector3 forceVector = mousePos - obj.transform.position;
            obj.ApplyForce(forceVector);
        }*/
    }

    public void onLeftClick()
    {

    }

    public void onRightClick() // spawn bear
    {
        if (!(Time.time < cooldownTimestamp))
        {
            cooldownTimestamp = Time.time + cooldown; //firerate - cooldown

            Obstacle bear = Instantiate(bearPrefab, mousePos, Quaternion.identity);
            agentManager.obstacles.Add(bear);
        }
    }
}
