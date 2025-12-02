using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShootScript : MonoBehaviour
{
    [SerializeField] private float _duration;
    public float Duration
    {
        get
        {
            return _duration;
        }
    }
}