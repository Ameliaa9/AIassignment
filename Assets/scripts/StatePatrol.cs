using UnityEngine;

public class StatePatrol : State
{
    //constructor
    public StatePatrol(AIController ai) : base(ai) { }

    public override void Enter()
    {
        Debug.Log("Entering Patrol State");
    }

    public override void Update()
    {
        if (ai.CanSeePlayer())
        {
            //Debug.Log("Can see player");
            ai.ChangeState(new StateChase(ai));
        }
        else if (ai.CanHearPlayer(ai.playerVolume) && !ai.CanSeePlayer())
        {
            ai.ChangeState(new StateSearchForPlayer(ai));
        }
        else
        {

            ai.Patrol();
        }
    }

    public override void Exit()
    {
        //Debug.Log("Exiting Patrol State");
    }
}