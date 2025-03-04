using UnityEngine;

public abstract class DragItem : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Debug.Assert(spriteRenderer != null, $"Component {nameof(SpriteRenderer)} has not been set to this object");
    }

    public virtual void MoveTo(Vector2 position)
    {
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }

    public void SetOrderInLayer(int index)
    {
        spriteRenderer.sortingOrder = index + 1;
    }

    public abstract void CancelMovement();
}