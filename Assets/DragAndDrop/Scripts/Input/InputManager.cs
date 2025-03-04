using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private IAS_Default_InputMap _inputMap;

    public bool IsInteract { get; private set; }

    public Vector2 MoveValue { get; private set; }

    public Vector2 DragValue { get; private set; }

    private void Awake()
    {
        _inputMap = new IAS_Default_InputMap();
    }

    private void OnEnable()
    {
        _inputMap.Enable();

        _inputMap.Player.Move.performed += Move;
        _inputMap.Player.Move.canceled += Move;

        _inputMap.Player.Drag.performed += Drag;
        _inputMap.Player.Drag.canceled += Drag;

        _inputMap.Player.Interact.started += Interact;
        _inputMap.Player.Interact.canceled += Interact;
    }

    private void OnDisable()
    {
        _inputMap.Disable();
    }

    private void Interact(InputAction.CallbackContext context)
    {
        IsInteract = context.ReadValue<float>() > 0;
    }

    private void Move(InputAction.CallbackContext context)
    {
        MoveValue = context.ReadValue<Vector2>();
    }

    private void Drag(InputAction.CallbackContext context)
    {
        DragValue = context.ReadValue<Vector2>();
    }
}
