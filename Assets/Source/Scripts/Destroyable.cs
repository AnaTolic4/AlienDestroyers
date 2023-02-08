using UnityEngine;

public sealed class Destroyable : Target
{
    [SerializeField] private EnvironmentObject _environmentObject;

    public override int Reward => _environmentObject.Reward;

    public override bool IsTargetHit { get; protected set; }

    public override void Hit()
    {
        if (!IsTargetHit)
        {
            InitRigidbody(gameObject, _environmentObject.Mass);
            IsTargetHit = true;
        }
    }
}
