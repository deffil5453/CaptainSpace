using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealEvent : MonoBehaviour
{
    public static Action<float> OnHealthChanged;
    public static void AddHealth(float value)
    {
        OnHealthChanged?.Invoke(value);
    }
}
