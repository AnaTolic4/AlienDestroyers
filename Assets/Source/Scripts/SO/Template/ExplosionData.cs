using UnityEngine;

[CreateAssetMenu(fileName = "New Explosion", menuName = "Explosion")]
public class ExplosionData : ScriptableObjectSingleton<ExplosionData>
{
    [SerializeField] private float _force;
    [SerializeField] private float _radius;
    [SerializeField] private float _delay;

    public float Force => _force;
    public float Radius => _radius;
    public float Delay => _delay;
}
