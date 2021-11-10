using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class PlayerInput : MonoBehaviour, IDragHandler
{
    [SerializeField] private RectTransform _gameField;
    [SerializeField] private PlayerMovement _playerMovement;
    
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        _playerMovement.Move(eventData.delta * 3);
    }
}
