using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvunerabilityControl : MonoBehaviour
{
    [SerializeField] private float _invunerabilityDuration;
    public float GetInvunerabilityDuration()
    {
        return _invunerabilityDuration;
    }
}
