using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    [SerializeField]
    Wanderer beePrefab;
    [SerializeField]
    Wanderer bearPrefab;

    [SerializeField]
    uint numWanderers;

    /*[SerializeField]
    TagPlayer playerPrefab;

    [SerializeField]
    uint playerCount;*/

    List<Agent> bees;
    List<Agent> bears;
    public List<Obstacle> obstacles;

    //public Sprite[] tagSprites;

    [SerializeField]
    private float countTimer;

    public float CountTimer { get { return countTimer; } }

    public List<Agent> Bees { get { return bees; } }
    public List<Agent> Bears { get { return bears; } }

    //public Agent itPlayer;

    // Start is called before the first frame update
    void Start()
    {
        bees = new List<Agent>();

        /*for(uint i = 0; i < numWanderers; i++)
        {
            SpawnWanderer();
        }*/

        for(uint i = 0; i < numWanderers; i++)
        {
            SpawnBee();
        }

        /*if(agents.Count > 0)
        {
            ((TagPlayer)agents[0]).SetState(TagStates.Counting);
            itPlayer = agents[0];
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnBee()
    {
        Wanderer bee = Instantiate(beePrefab, transform);
        bee.AgentManager = this;
        bees.Add(bee);
    }

    private void SpawnBear()
    {
        Wanderer bear = Instantiate(bearPrefab, transform);
        bear.AgentManager = this;
        bees.Add(bear);
    }

    /*private void SpawnPlayer ()
    {
        TagPlayer player = Instantiate(playerPrefab, transform);
        player.AgentManager = this;
        agents.Add(player);
    }*/
}
