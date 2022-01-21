using UnityEngine;

public abstract class BonusField : MonoBehaviour
{
    protected float _seconds = 0f;

    private float _time = 0f;
    private bool _isTimerOn = false;

    protected virtual void FixedUpdate()
    {
        if (_isTimerOn)
            SetTimer();
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        Destroy(gameObject);
    }

    public void SetTimeSeconds(float time)
    {
        _seconds = time;
        _time = time;

        _isTimerOn = true;
    }

    protected virtual void SetTimer()
    {
        if (_seconds <= 0f)
        {
            _seconds = 0;
            _isTimerOn = false;

            Hide();
        }
        else
            _seconds -= Time.fixedDeltaTime;
    }

    protected abstract void OnTriggerStay2D(Collider2D collision);
}
