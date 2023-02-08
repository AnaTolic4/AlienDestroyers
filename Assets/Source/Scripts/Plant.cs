using UnityEngine;

[RequireComponent(typeof(Ram))]
public sealed class Plant : Target
{
    [SerializeField] private EnvironmentObject _environment;

    public override int Reward => _environment.Reward;

    public override bool IsTargetHit { get ; protected set ; }

    public override void Hit()
    {
        if (!IsTargetHit)
        {
            InitRigidbody(gameObject, _environment.Mass);
            GetComponent<Ram>().Activate();
            IsTargetHit = true;
        }
    }
}
