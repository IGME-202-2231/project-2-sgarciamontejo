using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    [SerializeField]
    Bee beePrefab;
    [SerializeField]
    Bear bearPrefab;

    [SerializeField]
    uint numBees;

    /*[SerializeField]
    TagPlayer playerPrefab;

    [SerializeField]
    uint playerCount;*/

    List<Agent> bees;
    public List<Agent> bears;

    public List<GameObject> flowers;
    public List<Obstacle> obstacles;

    [SerializeField]
    private float countTimer;
    public float CountTimer { get { return countTimer; } }

    public List<Agent> Bees { get { return bees; } }
    public List<Agent> Bears { get { return bears; } }
    public List<GameObject> Flowers {  get { return flowers; } }

    //public Agent itPlayer;

    // Start is called before the first frame update
    void Start()
    {
        bees = new List<Agent>();
        bears = new List<Agent>();

        for(uint i = 0; i < numBees; i++)
        {
            SpawnBee();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnBee()
    {
        Bee bee = Instantiate(beePrefab, transform);
        bee.AgentManager = this;
        bees.Add(bee);
    }
}
