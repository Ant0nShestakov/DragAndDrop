using UnityEngine;

public abstract class ActionState : MonoBehaviour
{
    protected FiniteStateMachine finiteStateMachine;

    public void Initialize(FiniteStateMachine finiteStateMachine)
    {
        this.finiteStateMachine = finiteStateMachine;
    }

    public abstract void EnterState();

    public abstract void ExitState();

    public abstract void UpdateState();
}
