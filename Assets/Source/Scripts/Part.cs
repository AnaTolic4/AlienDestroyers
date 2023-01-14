using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    [SerializeField] private float energyThreshold;
    [SerializeField] private float detectDistance;

    private Collider selfCollider;
    private Rigidbody rb;
    private RaycastHit hit;
    private float defaultDistance;

    private void OnValidate()
    {
        if (energyThreshold < 0)
            energyThreshold = 0f;

        if (detectDistance < 0.1)
            detectDistance = 0.1f;

    }

    private void OnEnable()
    {
        TryGetComponent(out Rigidbody rigidbody);

        if(rigidbody == null)
        {
            gameObject.AddComponent<Rigidbody>();
        }
    }

    private void Start()
    {
        selfCollider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        defaultDistance = selfCollider.bounds.extents.magnitude + detectDistance;
        rb.AddForce(new Vector3(30, 0, 0), ForceMode.Impulse);
    }

    private void Update()
    {
        if (rb.mass * rb.velocity.magnitude * 0.5f >= energyThreshold)
        {
            Physics.Raycast(selfCollider.bounds.center, rb.velocity.normalized, out hit, defaultDistance);
            Debug.DrawRay(selfCollider.bounds.center, rb.velocity.normalized * defaultDistance, Color.red);

            if (hit.collider != null)
            {
                hit.collider.gameObject.TryGetComponent(out Part part);

                if (part != null && !part.enabled)
                    part.enabled = true;

                Debug.Log(hit.collider.name);
            }
        }
    }
}
