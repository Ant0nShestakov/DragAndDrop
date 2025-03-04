using System;
using UnityEngine;

public class PlayerBehaviourStateMachine : FiniteStateMachine
{
    public event Action<Vector2> OnPlayerMove;

    public DragItem CurrentDragItem { get; private set; }

    public PlayerBehaviourStateMachine(PlayerActionState[] actionStates) : base(actionStates)
    {
        SwitchState<PlayerIdleState>();
    }

    public void DragCamera(Vector2 pos)
    {
        OnPlayerMove?.Invoke(pos);
    }

    public void SetDragItem(DragItem dragItem)
    {
        CurrentDragItem = dragItem;
    }
}