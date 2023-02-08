using UnityEngine;

[CreateAssetMenu(fileName = "New Vehicle",menuName = "Vehicle", order = 19)]
public class Vehicle : EnvironmentObject
{
    [SerializeField] private bool _hasRaming;

    public bool HasRaming => _hasRaming;
}
