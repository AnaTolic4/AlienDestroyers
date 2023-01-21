using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Part : MonoBehaviour
{
    public abstract int Id {get; set; }

    public abstract Rigidbody Detouch();
  
}
