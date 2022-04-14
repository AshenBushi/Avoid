using TMPro;
using UnityEngine;

public class MoneyDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMoney;

    private void Start()
    {
        _textMoney.text = SavingSystem.Instance.Data.Money.ToString();
    }
}
