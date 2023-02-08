using UnityEngine;

public abstract class Target : MonoBehaviour
{
    public abstract int Reward { get; }
    public abstract bool IsTargetHit { get; protected set; }

    public abstract void Hit();

    protected Rigidbody InitRigidbody(GameObject gameObject, float mass = 1f)
    {
        var rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        rigidbody.mass = mass;

        return rigidbody;
    }
}
