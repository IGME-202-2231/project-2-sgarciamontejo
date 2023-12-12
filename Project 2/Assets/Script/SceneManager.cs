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
    Agent bearPrefab;

    [SerializeField]
    GameObject flowerPrefab;

    Vector3 mousePos;

    float cooldown = 2f;
    float cooldownTimestamp1; //bear
    float cooldownTimestamp2; //flower

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
        if (!(Time.time < cooldownTimestamp2))
        {
            cooldownTimestamp2 = Time.time + cooldown; //firerate - cooldown

            GameObject flower = Instantiate(flowerPrefab, mousePos, Quaternion.identity);
            agentManager.flowers.Add(flower);
        }
    }

    public void onRightClick() // spawn bear
    {
        if (!(Time.time < cooldownTimestamp1))
        {
            cooldownTimestamp1 = Time.time + cooldown; //firerate - cooldown

            Agent bear = Instantiate(bearPrefab, mousePos, Quaternion.identity);
            agentManager.bears.Add(bear);
            bear.AgentManager = agentManager;
        }
    }
}
