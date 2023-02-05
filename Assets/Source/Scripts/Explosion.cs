using UnityEngine;

public sealed class Explosion : Demolisher
{
    private float _force;
    private float _radius;
    private float _delay;

    private void Start()
    {
        _force = ExplosionData.Instance.Force;
        _radius = ExplosionData.Instance.Radius;
        _delay = ExplosionData.Instance.Delay;
    }

    protected override void Demolish(Vector3 sourcePoint)
    {
        
    }
}
