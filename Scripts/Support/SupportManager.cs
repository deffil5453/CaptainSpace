using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SupportManager : MonoBehaviour
{
    public static SupportManager Instance;
    private SupportControl _supportControl;
    [SerializeField] private List<GameObject> _supports;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SupportActive(GameObject support, ShipControl ship)
    {
        
        _supportControl = support.GetComponent<SupportControl>();
        _supportControl.PickUp(ship);
    }
}