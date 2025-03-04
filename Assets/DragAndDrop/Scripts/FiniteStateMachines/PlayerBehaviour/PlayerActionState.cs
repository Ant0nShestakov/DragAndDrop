using UnityEngine;

public abstract class PlayerActionState : ActionState
{
    protected PlayerBehaviourStateMachine playerStateMachine;

    protected InputManager inputManager;
    protected PhysicsController physicsController;

    protected Camera mainCamera;

    protected void Awake()
    {
        inputManager = GetComponentInParent<InputManager>();
        Debug.Assert(inputManager != null, $"Component {nameof(InputManager)} has not been set to this object");

        physicsController = GetComponentInParent<PhysicsController>();
        Debug.Assert(physicsController != null, $"Component {nameof(PhysicsController)} has not been set to this object");

        mainCamera = Camera.main;
    }
}