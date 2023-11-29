using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneManager : MonoBehaviour
{
    //[SerializeField] List<PhysicsObject> objects;

    Vector3 mousePos;

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

    }
}
