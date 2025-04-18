using UnityEngine;
using System.Collections; 
 

public class StateChase : State
{
    // Constructor
    public StateChase(AIController ai) : base(ai) { }

    public override void Enter()
    {
        // Show "RUN!" UI when chase starts
        if (ai.runTextUI != null)
        {
            ai.runTextUI.SetActive(true);
            ai.StartCoroutine(HideRunText());
        }
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
        
        if (ai.runTextUI != null)
        {
            ai.runTextUI.SetActive(false);
        }
    }

    private IEnumerator HideRunText()
    {
        yield return new WaitForSeconds(2f);
        if (ai.runTextUI != null)
        {
            ai.runTextUI.SetActive(false);
        }
    }
}