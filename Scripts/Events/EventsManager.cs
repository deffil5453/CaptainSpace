using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static event Action<int> UpEvent;
    public static void UpActivation(int value)
    {
        UpEvent?.Invoke(value);
    }
}
