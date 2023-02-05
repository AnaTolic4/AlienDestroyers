using UnityEngine;

[CreateAssetMenu(fileName = "New Ram",menuName = "Ram")]
public class RamData : ScriptableObjectSingleton<RamData>
{
    [SerializeField] private float _pushForce;
    [SerializeField] private float _radius;

    public float PushForce => _pushForce;
    public float Radius => _radius;
}
