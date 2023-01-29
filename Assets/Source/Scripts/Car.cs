using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Car : MonoBehaviour, IDestroyable
{
    [SerializeField] private float _detectionDistance;

    private List<PartDetector> _carParts;
    private Rigidbody _rb;

    public delegate void Impact(Rigidbody rigidbody, float distance);
    public event Impact OnImpact;

    private void Start()
    {
        _carParts = GetComponentsInChildren<PartDetector>().ToList();
        _rb = GetComponent<Rigidbody>();
        SetActiveParts(false);
    }

    private void Update()
    {
        if (_rb.IsSleeping())
        {
            SetActiveParts(false);
        }
    }

    private void OnValidate()
    {
        if (_detectionDistance < 0.1)
            _detectionDistance = 0.1f;
    }

    private void SetActiveParts(bool value)
    {
        foreach (PartDetector part in _carParts)
        {
            part.gameObject.SetActive(value);
        }
    }

    public void WakeUp()
    {
        SetActiveParts(true);
        OnImpact?.Invoke(_rb, _detectionDistance);
    }

    public void ExplosionImpact(float exlosionForce, Vector3 explosionPosition, float radius)
    {
        _rb.AddExplosionForce(exlosionForce, explosionPosition, radius,1f, ForceMode.Impulse);
    }

    public void CollisionImpact(Vector3 forceDirection)
    {
        _rb.AddForce(forceDirection, ForceMode.Force);
    }
}
