using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Demolisher : MonoBehaviour
{
    protected abstract void Demolish(Vector3 sourcePoint);
}
