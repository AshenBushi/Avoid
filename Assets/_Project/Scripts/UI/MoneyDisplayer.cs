using TMPro;
using UnityEngine;

public class MoneyDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMoney;

    private void Start()
    {
        Bank.Instance.MoneyTextChangedEvent.AddListener(UpdateText);
        _textMoney.text = Bank.Instance.GetMoney().ToString();
    }

    private void OnDisable()
    {
        Bank.Instance.MoneyTextChangedEvent.RemoveListener(UpdateText);
    }

    public void UpdateText(int moneyAmount)
    {
        _textMoney.text = moneyAmount.ToString();
    }
}
