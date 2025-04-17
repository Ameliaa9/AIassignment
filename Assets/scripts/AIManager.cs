using UnityEngine;
using System.Collections.Generic;

public class AIManager : MonoBehaviour
{
    public static AIManager Instance { get; private set; }

    //player spotted
    //last known player pos
    //list of agents that want to make use of shared alerts
    public Vector3 lastKnownPlayerPos;

    //Registered agents
    public List<AIController> registeredAgents = new List<AIController>();
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void RegisterAgent(AIController ai)
    {
        if (ai.isManaged)
        {
            registeredAgents.Add(ai);
        }
    }

    public void UnregisterAgent(AIController ai)
    {
        if (ai.isManaged)
        {
            registeredAgents.Remove(ai);
        }
    }

    //alert player spotted
    public void AlertPlayerSpotted()
    {
        //player spotted = true
        //update player position

        //notify all managed agents

        foreach (var ai in registeredAgents)
        {
            ai.ChangeState(new StateSearchForPlayer(ai));
        }
    }

}
