using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SupportControl : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private SpriteRenderer _icon;
    public static event Action<SpriteRenderer, float> OnSupporPickUp;
    public float Duration
    {
        get
        {
            return _duration;
        }
    }
    public abstract void PickUp(ShipControl ship);
    protected void PickupEvent()
    {
        OnSupporPickUp?.Invoke(_icon, _duration);
    }
}