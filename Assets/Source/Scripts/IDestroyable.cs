using UnityEngine;

public interface IDestroyable
{
    public void WakeUp();
    public void ExplosionImpact(float exlosionForce, Vector3 explosionPosition, float radius);
    public void CollisionImpact(Vector3 forceDirection);
}
