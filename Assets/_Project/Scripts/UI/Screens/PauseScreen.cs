using UnityEngine;

public class PauseScreen : UIScreen
{
    [SerializeField] private GameScreen _gameScreen;

    public override void Enable()
    {
        base.Enable();

        _gameScreen.SmallDimm();

        SoundManager.Instance.PlaySound(Sound.Button);

        Time.timeScale = 0f;
    }

    public override void Disable()
    {
        base.Disable();

        _gameScreen.Show();

        SoundManager.Instance.PlaySound(Sound.Button);

        Time.timeScale = 1f;
    }
}
