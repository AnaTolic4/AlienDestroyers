using UnityEngine;

[RequireComponent(typeof(Ram))]
public class Pickup : Target
{
    [SerializeField] private Vehicle _pickup;

    public override int Reward => _pickup.Reward;

    public override bool IsTargetHit { get; protected set; }

    public override void Hit()
    {
        if (!IsTargetHit)
        {
            InitRigidbody(gameObject, _pickup.Mass);
            IsTargetHit = true;

            if (_pickup.HasRaming)
            {
                GetComponent<Ram>().Activate();
            }
        }
    }
}
