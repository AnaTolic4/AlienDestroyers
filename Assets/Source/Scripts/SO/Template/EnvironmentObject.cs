using UnityEngine;

[CreateAssetMenu(fileName = "New Environment Object",menuName = "Environment Object",order = 17)]
public class EnvironmentObject : ScriptableObject
{
    [SerializeField] private int _reward;
    [SerializeField] private float _mass;

    public int Reward => _reward;
    public float Mass => _mass;
}
