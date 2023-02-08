using UnityEngine;

[CreateAssetMenu(fileName = "New Demolisher", menuName = "Demolisher", order = 20)]
public class Demolisher : ScriptableObject
{
    [SerializeField] private float _force;
    [SerializeField] private float _radius;

    public float Force => _force;
    public float Radius => _radius;
}
