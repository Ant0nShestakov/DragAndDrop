using UnityEngine;

public class PlayerIdleState : PlayerActionState
{
    private void CheckWithRaycast()
    {
        Ray ray = mainCamera.ScreenPointToRay(inputManager.DragValue);

        if (!physicsController.CastRayTo(ray, out RaycastHit2D raycastHit))
            return;

        if (raycastHit.collider.TryGetComponent<DragItem>(out DragItem dragItem))
        {
            playerStateMachine.SetDragItem(dragItem);
            playerStateMachine.SwitchState<PlayerMoveItemState>();
        }
        else
        {
            playerStateMachine.DragCamera(inputManager.MoveValue);
        }
    }

    public override void EnterState()
    {
        Debug.Log($"{name}:Enter");

        playerStateMachine = finiteStateMachine as PlayerBehaviourStateMachine 
            ?? throw new System.NotImplementedException(name);
    }

    public override void ExitState()
    {
        Debug.Log($"{name}:Exit");
    }

    public override void UpdateState()
    {
        if (inputManager.IsInteract)
            CheckWithRaycast();
    }
}
