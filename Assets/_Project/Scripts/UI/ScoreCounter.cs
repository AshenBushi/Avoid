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
    private int _waveCounter = 1;
    private bool _isMazeCreated;

    public int Score { get; private set; } = 0;

    public static UnityEvent OnMazeActivationEvent = new UnityEvent();
    
    public const int SCORE_FOR_START_MAZE = 100;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        MazeController.MazeCompleteEvent.AddListener(SetWaveNumber);
    }

    private void Start()
    {
        SetWaveNumber();
    }

    private void OnDisable()
    {
        MazeController.MazeCompleteEvent.RemoveListener(SetWaveNumber);
    }

    public void AddScore()
    {
        Score++;

        _text.text = Score.ToString();

        if (Score % SCORE_FOR_START_MAZE == 0 && Score != 0 && !_isMazeCreated)
        {
            _isMazeCreated = true;
            OnMazeActivationEvent?.Invoke();
        }
    }

    private void SetWaveNumber()
    {
        _isMazeCreated = false;
        _textWaveNumber.text = "Wave " + (_waveCounter);
        _waveCounter++;
        _tween = _textWaveNumber.DOFade(1f, 0.5f).SetLink(gameObject);

        _tween.OnComplete(() =>
        {
            _textWaveNumber.DOFade(0f, 2f).SetLink(gameObject);
        });
    }
}
