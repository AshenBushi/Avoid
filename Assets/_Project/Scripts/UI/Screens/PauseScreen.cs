using UnityEngine;

public class PauseScreen : UIScreen
{
    public override void Enable()
    {
        base.Enable();

        SoundManager.Instance.PlaySound(Sound.Button);
        
        Time.timeScale = 0f;
    }

    public override void Disable()
    {
        base.Disable();

        SoundManager.Instance.PlaySound(Sound.Button);
        
        Time.timeScale = 1f;
    }
}
