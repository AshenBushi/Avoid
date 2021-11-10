using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreCounter : MonoBehaviour
{
    private TMP_Text _text;
    
    public int Score { get; private set; } = 0;
    
    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void AddScore()
    {
        Score++;

        _text.text = Score.ToString();
    }
}
