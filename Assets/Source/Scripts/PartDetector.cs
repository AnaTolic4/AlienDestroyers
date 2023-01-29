using UnityEngine;

public class PartDetector : MonoBehaviour
{
    private Car _car;
    private Rigidbody _rb;
    private RaycastHit _hit;
    private float _detectionDistance;
    private float _colliderExtents;

    private void Awake()
    {
        _car = GetComponentInParent<Car>();
        _colliderExtents = _car.GetComponent<Collider>().bounds.extents.magnitude;
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
        Physics.Raycast(transform.position, _rb.velocity.normalized, out _hit, _detectionDistance);
        Debug.DrawRay(transform.position, _rb.velocity.normalized * _detectionDistance, Color.red);

        UnfreezParts(_hit.point, _colliderExtents);
    }

    private void UnfreezParts(Vector3 center, float radius)
    {
        foreach (Collider collider in Physics.OverlapSphere(center, radius))
        {
            if (collider.TryGetComponent(out IDestroyable destroyableObject))
            {
                destroyableObject.WakeUp();
            }
        }
    }

    private void SetParameters(Rigidbody rigidbody, float detectionDistance)
    {
        _detectionDistance = detectionDistance;
        _rb = rigidbody;
    }
}
