using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsDragItem : DragItem
{
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;

    protected override void Awake()
    {
        base.Awake();

        _rigidbody = GetComponent<Rigidbody2D>();
        Debug.Assert(_rigidbody != null, $"Component {nameof(Rigidbody2D)} has not been set to this object");

        _collider = GetComponent<Collider2D>();
        Debug.Assert(_collider != null, $"Component {nameof(Collider2D)} has not been set to this object");
    }

    public override void MoveTo(Vector2 position)
    {
        _rigidbody.simulated = false;
        _collider.enabled = false;

        base.MoveTo(position);
    }

    public override void CancelMovement()
    {
        _rigidbody.simulated = true;
        _collider.enabled = true;
    }
}