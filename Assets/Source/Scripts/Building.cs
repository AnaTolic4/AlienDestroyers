using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private float _destructionEnergyThreshold;
    
    private BuildingPart[] _parts;

    private void Awake()
    {
        _parts = GetComponentsInChildren<BuildingPart>();
        SetPartId();
    }

    public void DetouchPart(BuildingPart part)
    {
        //_parts[part.Id - 1] = null;
        //part.transform.parent = null;
    }

    private void SetPartId()
    {
        for (int i = 0; i < _parts.Length; i++)
        {
            _parts[i].Id = i + 1;
        }  
    }
}
