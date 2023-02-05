using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private TargetData _targetData;

    private void Start()
    {
        foreach(Target fragment in GetComponentsInChildren<Target>())
        {
            fragment.SetData(_targetData);
        }
    }
}
