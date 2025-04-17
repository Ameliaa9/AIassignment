using UnityEngine;

public abstract class State
{
    protected AIController ai;
    public State(AIController ai)
    {
        this.ai = ai;
    }

    public abstract void Enter();

    public abstract void Update();

    public abstract void Exit();
}