using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Car : MonoBehaviour, IDestroyable
{
    [SerializeField] private float _energyThreshold;
    [SerializeField] private float _detectionDistance;

    private List<PartDetector> _carParts;
    private Rigidbody _rb;
    private Collider _collider;
    private float _currentEnergy;

    public delegate void Impact(Rigidbody rigidbody, float distance);
    public event Impact OnImpact;

    private void Start()
    {
        _carParts = GetComponentsInChildren<PartDetector>().ToList();
        _collider = GetComponent<Collider>();
        SetActiveParts(false);
        enabled = false;
    }

    private void OnValidate()
    {
        if (_energyThreshold < 0)
            _energyThreshold = 0f;

        if (_detectionDistance < 0.1)
            _detectionDistance = 0.1f;
    }
    private void FixedUpdate()
    {
        _currentEnergy = _rb.mass * _rb.velocity.magnitude * 0.5f;
        Debug.Log(_currentEnergy);

        if(_currentEnergy < _energyThreshold)
        {
            SetActiveParts(false);
        }
        else
        {
            SetActiveParts(true);
        }
    }

    private void SetActiveParts(bool value)
    {
        foreach (PartDetector part in _carParts)
        {
            part.gameObject.SetActive(value);
        }

        _collider.enabled = !value;
    }

    public void WakeUp()
    {
        if (_rb == null)
        {
            _rb = gameObject.AddComponent<Rigidbody>();
            _rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }

        SetActiveParts(true);
        OnImpact?.Invoke(_rb, _detectionDistance);
        enabled = true;
    }

    public void ExplosionImpact(float exlosionForce, Vector3 explosionPosition, float radius)
    {
        _rb.AddExplosionForce(exlosionForce, explosionPosition, radius, 0, ForceMode.Impulse);
    }

    public void CollisionImpact(Vector3 forceDirection)
    {
        _rb.AddForce(forceDirection, ForceMode.Force);
    }
}
