using UnityEngine;

public sealed class Ram : Destruction
{
    [SerializeField] private Demolisher _demolisher;

    private float _pushForce;
    private float _radius;
    private Rigidbody _rigidbody;

    private void OnCollisionEnter(Collision collision)
    {
        if (_rigidbody == null)
            return;

        Vector3 point = collision.GetContact(0).point;
        Destruct(point);

        Debug.Log("Active");
    }

    protected override void Destruct(Vector3 sourcePoint)
    {
        foreach (Collider collider in Physics.OverlapSphere(sourcePoint, _radius))
        {
            if (collider.gameObject.TryGetComponent(out Target target) && !target.IsTargetHit)
            {
                target.Hit();

                Vector3 pushDirection = _rigidbody.velocity * _pushForce;
                collider.attachedRigidbody.AddForceAtPosition(pushDirection, sourcePoint, ForceMode.Impulse);
            }
        }
    }

    public void Activate()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _pushForce = _demolisher.Force;
        _radius = _demolisher.Radius;
    }
}
