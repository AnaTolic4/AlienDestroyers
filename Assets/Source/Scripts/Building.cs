using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private float _destructionEnergyThreshold;

    private Part[] _parts;

    private void Awake()
    {
        _parts = GetComponentsInChildren<Part>();
        SetPartId();
    }

    private void RemovePart(Part part)
    {
        _parts[part.Id - 1] = null;
        part.transform.parent = null;
        part.gameObject.AddComponent<Rigidbody>();
    }

    private void SetPartId()
    {
        for (int i = 0; i < _parts.Length; i++)
        {
            _parts[i].Id = i + 1;
        }  
    }
}
