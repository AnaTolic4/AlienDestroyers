using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : Part
{
    private bool _isDetouched;
    private Rigidbody _rb;

    public override int Id { get; set; }

    public override Rigidbody Detouch()
    {
        if (!_isDetouched)
        {
            _rb = gameObject.AddComponent<Rigidbody>();
            _rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            _isDetouched = true;
            return _rb;
        }

        return _rb;
    }
}
