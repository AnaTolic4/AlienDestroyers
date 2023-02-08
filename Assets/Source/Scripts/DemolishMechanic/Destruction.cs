using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Destruction : MonoBehaviour
{
    protected abstract void Destruct(Vector3 sourcePoint);
}
