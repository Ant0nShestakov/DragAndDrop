using UnityEngine;

[RequireComponent(typeof(InputManager), typeof(PhysicsController))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _leftConstraint;
    [SerializeField] private Transform _rightConstraint;

    [SerializeField] private float _speed;

    private FiniteStateMachine _stateMachine;

    private void Awake()
    {
        var actionStates = GetComponentsInChildren<PlayerActionState>();

        _stateMachine = new PlayerBehaviourStateMachine(actionStates);
    }

    private void OnEnable()
    {
        ((PlayerBehaviourStateMachine)_stateMachine).OnPlayerMove += Move;
    }

    private void OnDisable()
    {
        ((PlayerBehaviourStateMachine)_stateMachine).OnPlayerMove -= Move;
    }

    private void Update()
    {
        _stateMachine?.OnTick();
    }

    private void Move(Vector2 direction)
    {
        float step = _speed * Time.deltaTime;

        Vector3 target = transform.position + (Vector3)(-direction * step);
        target.x = Mathf.Clamp(target.x, _leftConstraint.position.x, _rightConstraint.position.x);

        transform.position = new Vector3(target.x, transform.position.y, transform.position.z);
    }

}
