using UnityEngine;

public class BuildingPart : MonoBehaviour, IDestroyable
{
    private Rigidbody _rigidbody;
    private bool _isImpacted;

    public int Id { get; set; }

    private void Start()
    {
        _isImpacted = false;
    }

    public void ExplosionImpact(float exlosionForce, Vector3 explosionPosition, float radius)
    {
        if(enabled)
            _rigidbody.AddExplosionForce(exlosionForce,explosionPosition, radius,1f,ForceMode.Impulse);
    }

    public void WakeUp()
    {
        if (_isImpacted)
            return;

        _isImpacted = true;
        _rigidbody = gameObject.AddComponent<Rigidbody>();
        _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        GetComponentInParent<Building>().DetouchPart(this);
    }

    public void CollisionImpact(Vector3 forceDirection)
    {
        _rigidbody.AddForce(forceDirection, ForceMode.Force);
    }
}
