using UnityEngine;

public class BuildingPart : MonoBehaviour, IDestroyable
{
    private Rigidbody _rb;
    private bool _isImpacted;

    public int Id { get; set; }

    private void Start()
    {
        _isImpacted = false;
    }

    public void ExplosionImpact(float exlosionForce, Vector3 explosionPosition, float radius)
    {
        if(enabled)
            _rb.AddExplosionForce(exlosionForce,explosionPosition, radius,0,ForceMode.Impulse);
    }

    public void WakeUp()
    {
        if (_isImpacted)
            return;

        _isImpacted = true;
        _rb = gameObject.AddComponent<Rigidbody>();
        _rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        GetComponentInParent<Building>().DetouchPart(this);
    }

    public void CollisionImpact(Vector3 forceDirection)
    {
        _rb.AddForce(forceDirection, ForceMode.Force);
    }
}
