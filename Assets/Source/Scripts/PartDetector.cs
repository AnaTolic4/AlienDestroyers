using UnityEngine;

public class PartDetector : MonoBehaviour
{
    private Collider _selfCollider;
    private Car _car;
    private Rigidbody _rb;
    private RaycastHit _hit;
    private float _detectionDistance;

    private void Awake()
    {
        _car = GetComponentInParent<Car>();
        _selfCollider = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        _car.OnImpact += SetParameters;
    }

    private void OnDisable()
    {
        _car.OnImpact -= SetParameters;
    }

    private void Update()
    {
        Physics.Raycast(_selfCollider.bounds.center, _rb.velocity.normalized, out _hit, _detectionDistance);
        Debug.DrawRay(_selfCollider.bounds.center, _rb.velocity.normalized * _detectionDistance, Color.red);

        AwakenParts(_hit.point, _selfCollider.bounds.extents.magnitude);
    }

    private void AwakenParts(Vector3 center, float radius)
    {
        foreach (Collider collider in Physics.OverlapSphere(center, radius))
        {
            if (collider.TryGetComponent(out IDestroyable destroyableObject))
            {
                destroyableObject.WakeUp();
                destroyableObject.CollisionImpact(_rb.velocity);
            }
        }
    }

    private void SetParameters(Rigidbody rigidbody,float detectionDistance)
    {
        _detectionDistance = _selfCollider.bounds.extents.magnitude + detectionDistance;
        _rb = rigidbody;
    }
}
