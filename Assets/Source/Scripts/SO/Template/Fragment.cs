using UnityEngine;

[CreateAssetMenu(fileName = "New Frament", menuName = "Fragment",order = 18)]
public class Fragment : ScriptableObject
{
    [SerializeField] private int _reward;
    [SerializeField] private float _minimumlMass;
    [SerializeField] private bool _massBySize;

    public int Reward => _reward;
    public float MinimumMass => _minimumlMass;
    public bool HasMassBySize => _massBySize;
}
