using UnityEngine;

public sealed class Target : MonoBehaviour
{
    [SerializeField] private bool _demolisher;

    private int _reward;
    private float _mass;
    private Rigidbody _rigidbody;

    public bool IsTargetHit { get; private set; }

    public int Reward => _reward;

    private void Start()
    {
        _reward = TargetData.Instance.Reward;
        _mass = TargetData.Instance.Mass;
    }

    public void Hit()
    {
        InitRigidbody();
        IsTargetHit = true;

        if (_demolisher)
            gameObject.AddComponent<Ram>();
    }

    private void InitRigidbody()
    {
        if (_rigidbody != null)
            return;

        _rigidbody = gameObject.AddComponent<Rigidbody>();
        _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        _rigidbody.mass = _mass;
    }
}
