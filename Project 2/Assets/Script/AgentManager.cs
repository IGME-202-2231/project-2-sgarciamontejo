using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    [SerializeField]
    Wanderer wandererPrefab;

    [SerializeField]
    uint numWanderers;

    /*[SerializeField]
    TagPlayer playerPrefab;

    [SerializeField]
    uint playerCount;*/

    List<Agent> agents;

    //public Sprite[] tagSprites;

    [SerializeField]
    private float countTimer;

    public float CountTimer { get { return countTimer; } }

    public List<Agent> Agents { get { return agents; } }

    //public Agent itPlayer;

    // Start is called before the first frame update
    void Start()
    {
        agents = new List<Agent>();

        /*for(uint i = 0; i < numWanderers; i++)
        {
            SpawnWanderer();
        }*/

        for(uint i = 0; i < numWanderers; i++)
        {
            SpawnWanderer();
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

    private void SpawnWanderer()
    {
        Wanderer wanderer = Instantiate(wandererPrefab, transform);
        wanderer.AgentManager = this;
        agents.Add(wanderer);
    }

    /*private void SpawnPlayer ()
    {
        TagPlayer player = Instantiate(playerPrefab, transform);
        player.AgentManager = this;
        agents.Add(player);
    }*/
}
