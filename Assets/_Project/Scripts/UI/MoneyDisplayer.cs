using TMPro;
using UnityEngine;

public class MoneyDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMoney;

    private void Awake()
    {
        Bank.Instance.MoneyTextChangedEvent.AddListener(UpdateText);
    }

    private void Start()
    {
        _textMoney.text = Bank.Instance.GetMoney().ToString();
    }

    public void UpdateText(int moneyAmount)
    {
        _textMoney.text = moneyAmount.ToString();
    }
}
