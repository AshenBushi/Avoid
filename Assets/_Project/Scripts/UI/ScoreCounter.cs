using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TMP_Text))]
public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _textWaveNumber;
    private TMP_Text _text;
    private Tween _tween;

    public int Score { get; private set; } = 0;

    public static UnityEvent OnMazeActivationEvent = new UnityEvent();

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        MazeMovingController.MazeCompleteEvent.AddListener(SetWaveNumber);
    }

    private void Start()
    {
        SetWaveNumber();
    }

    private void OnDisable()
    {
        MazeMovingController.MazeCompleteEvent.RemoveListener(SetWaveNumber);
    }

    public void AddScore()
    {
        Score++;

        _text.text = Score.ToString();

        if (Score % 100 == 0 && Score != 0)
        {
            OnMazeActivationEvent?.Invoke();
        }
    }

    private void SetWaveNumber()
    {
        _textWaveNumber.text = "Wave " + ((Score % 100) + 1);
        _tween = _textWaveNumber.DOFade(1f, 0.5f).SetLink(gameObject);

        _tween.OnComplete(() =>
        {
            _textWaveNumber.DOFade(0f, 2f).SetLink(gameObject);
        });
    }
}
