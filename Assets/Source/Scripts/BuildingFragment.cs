using UnityEngine;

public sealed class BuildingFragment : Target
{
    private int _reward;
    private float _mass;

    public override int Reward => _reward;

    public override bool IsTargetHit { get; protected set; }

    public override void Hit()
    {
        if (!IsTargetHit)
        {
            InitRigidbody(gameObject,_mass);
            IsTargetHit = true;
        }
    }

    public void SetData(int reward, bool massBySize, float minimumMass = 1f)
    {
        _reward = reward;

        if (massBySize)
        {
            float currentMass = GetComponent<Collider>().bounds.size.magnitude;
            _mass = currentMass >= minimumMass ? currentMass : minimumMass;
        }
        else
        {
            _mass = minimumMass;
        }

    }
}
