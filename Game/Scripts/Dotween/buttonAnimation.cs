using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class buttonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 _localScale;
    private Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {        
        _localScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_button.interactable == true)
        {
            transform.DOScale(_localScale * 1.1f, 0.5f);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(_localScale, 0.5f);
    }
}