using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TMP_Text))]
public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _textWaveNumber;
    private TMP_Text _text;
    private int _waveCounter = 1;

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
        StartScreen.OnGameStart += SetWaveNumber;
    }

    private void OnDisable()
    {
        MazeController.MazeCompleteEvent.RemoveListener(SetWaveNumber);
        StartScreen.OnGameStart -= SetWaveNumber;
    }

    public void AddScore()
    {
        Score++;

        _text.text = Score.ToString();

        if (Score % SCORE_FOR_START_MAZE == 0 && Score != 0)
        {
            OnMazeActivationEvent?.Invoke();
        }
    }

    private void SetWaveNumber()
    {
        _textWaveNumber.text = "Wave " + (_waveCounter);
        _waveCounter++;

        StartCoroutine(FadeTextWave());
    }

    private IEnumerator FadeTextWave()
    {
        yield return new WaitForSeconds(0.5f);
        _textWaveNumber.DOFade(1f, 1.5f).SetLink(gameObject);
        yield return new WaitForSeconds(1f);
        _textWaveNumber.DOFade(0f, 1.5f).SetLink(gameObject);
    }
}
