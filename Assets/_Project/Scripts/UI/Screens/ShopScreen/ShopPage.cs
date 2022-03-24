using UnityEngine;

public class ShopPage : MonoBehaviour
{
    private int _index;

    public int Index => _index;

    public void Init(int index)
    {
        _index = index;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
