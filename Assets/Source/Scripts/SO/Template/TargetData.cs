using UnityEngine;

[CreateAssetMenu(fileName = "New Target", menuName = "Target")]
public class TargetData : ScriptableObjectSingleton<TargetData>
{
    [SerializeField] private int _reward;
    [SerializeField] private float _mass;

    public float Mass => _mass;
    public int Reward => _reward;
}
