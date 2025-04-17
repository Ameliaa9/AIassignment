using UnityEngine;

public class StateChase : State
{

    //constructor
    public StateChase(AIController ai) : base(ai) { }

    public override void Enter()
    {
        //Debug.Log("Entering Chase State");
    }

    public override void Update()
    {
        ai.ChasePlayer();
        if (!ai.CanSeePlayer())
        {
            ai.ChangeState(new StateSearchForPlayer(ai));
        }
    }

    public override void Exit()
    {
        //Debug.Log("Exiting Chase State");
    }
}