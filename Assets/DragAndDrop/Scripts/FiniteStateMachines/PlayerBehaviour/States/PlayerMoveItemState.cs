using UnityEngine;

public class PlayerMoveItemState : PlayerActionState
{
    private DragItem _currentDragItem;

    private void MoveWithRaycast()
    {
        Ray ray = mainCamera.ScreenPointToRay(inputManager.DragValue);

        if (!physicsController.CastRayTo(ray, out RaycastHit2D raycastHit))
            return;

        if (raycastHit.collider.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))
            _currentDragItem.SetOrderInLayer(spriteRenderer.sortingOrder);

        _currentDragItem.MoveTo(raycastHit.point);
    }

    public override void EnterState()
    {
        Debug.Log($"{name}:Enter");

        playerStateMachine = finiteStateMachine as PlayerBehaviourStateMachine 
            ?? throw new System.NotImplementedException(name);

        _currentDragItem = playerStateMachine.CurrentDragItem;
    }

    public override void ExitState()
    {
        _currentDragItem.CancelMovement();

        playerStateMachine.SetDragItem(null);

        Debug.Log($"{name}:Exit");
    }

    public override void UpdateState()
    {
        if (inputManager.IsInteract)
        {
            MoveWithRaycast();
        }
        else
        {
            finiteStateMachine.SwitchState<PlayerIdleState>();
        }
    }
}