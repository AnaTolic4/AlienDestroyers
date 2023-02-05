using UnityEngine;

public sealed class Ram : Demolisher
{
    private float _pushForce;
    private float _radius;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _pushForce = RamData.Instance.PushForce;
        _radius = RamData.Instance.Radius;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_rigidbody == null)
            return;

        Vector3 point = collision.GetContact(0).point;
        Demolish(point);

        Debug.Log("Active");
    }

    protected override void Demolish(Vector3 sourcePoint)
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
}
