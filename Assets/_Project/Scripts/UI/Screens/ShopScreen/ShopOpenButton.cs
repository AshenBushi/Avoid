using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShopOpenButton : MonoBehaviour
{
    [SerializeField] private UIScreen _shopScreen;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(_shopScreen.Enable);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(_shopScreen.Enable);
    }
}
