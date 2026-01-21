using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SupportControl : MonoBehaviour
{
    [SerializeField] private float _duration;
    public float Duration
    {
        get
        {
            return _duration;
        }
    }
    public abstract void PickUp(ShipControl ship);
}