using System;
using System.Collections.Generic;

public abstract class FiniteStateMachine
{
    protected readonly Dictionary<Type, ActionState> states;
    protected ActionState currentState;

    public FiniteStateMachine(ActionState[] actionStates)
    {
        states = new Dictionary<Type, ActionState>();

        foreach (var state in actionStates)
        {
            state.Initialize(this);
            states.Add(state.GetType(), state);
        }
    }

    public void OnTick()
    {
        currentState?.UpdateState();
    }

    public void SwitchState<T>() where T : ActionState
    {
        ActionState newState = states.GetValueOrDefault(typeof(T));

        if (newState == null)
            return;

        currentState?.ExitState();
        currentState = newState;
        currentState.EnterState();
    }
}
