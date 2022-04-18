using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Bank : Singleton<Bank>
{
    [HideInInspector] public UnityEvent<int> MoneyTextChangedEvent = new UnityEvent<int>();
    private int _prevMoneyAmount;

    public int GetMoney()
    {
        return SavingSystem.Instance.Data.Money;
    }

    public void AddMoney(int amount)
    {
        SavingSystem.Instance.Data.Money += amount;
    }

    public bool TryWithdrawMoney(int amount)
    {
        if (SavingSystem.Instance.Data.Money < amount)
            return false;

        _prevMoneyAmount = SavingSystem.Instance.Data.Money;
        SavingSystem.Instance.Data.Money -= amount;

        StartCoroutine(AccrueRoutine(amount));
        return true;
    }

    private IEnumerator AccrueRoutine(int amount)
    {
        var money = amount - _prevMoneyAmount;
        var time = 0.07f / (Mathf.Abs(money * 2));

        while (_prevMoneyAmount != money)
        {
            if (money < 0)
            {
                _prevMoneyAmount--;

                if (_prevMoneyAmount < SavingSystem.Instance.Data.Money)
                {
                    _prevMoneyAmount = SavingSystem.Instance.Data.Money;
                    MoneyTextChangedEvent?.Invoke(SavingSystem.Instance.Data.Money);
                    yield break;
                }
            }
            else
            {
                _prevMoneyAmount++;

                if (_prevMoneyAmount > SavingSystem.Instance.Data.Money)
                {
                    _prevMoneyAmount = SavingSystem.Instance.Data.Money;
                    MoneyTextChangedEvent?.Invoke(SavingSystem.Instance.Data.Money);
                    yield break;
                }
            }

            MoneyTextChangedEvent?.Invoke(_prevMoneyAmount);

            time -= 0.00003f;
            yield return new WaitForSeconds(time);
        }
    }
}
