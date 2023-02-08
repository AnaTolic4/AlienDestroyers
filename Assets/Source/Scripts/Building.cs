using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Fragment _fragment;

    private void Awake()
    {
        foreach (Collider collider in GetComponentsInChildren<Collider>())
        {
            BuildingFragment fragment = collider.gameObject.AddComponent<BuildingFragment>();
            fragment.SetData(_fragment.Reward, _fragment.HasMassBySize, _fragment.MinimumMass);
        }
    }
}
