using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    [SerializeField] private LayerMask _collisionLayerMask;

    public bool CastRayTo(Ray ray, out RaycastHit2D raycastHit)
    {
        raycastHit = Physics2D.Raycast(ray.origin, ray.direction, _collisionLayerMask);

        return raycastHit.collider != null;
    }
}