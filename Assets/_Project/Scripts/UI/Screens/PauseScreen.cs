using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : UIScreen
{
    public override void Show()
    {
        base.Show();

        SoundManager.Instance.PlaySound(Sound.Button);
        
        Time.timeScale = 0f;
    }

    public override void Hide()
    {
        base.Hide();

        SoundManager.Instance.PlaySound(Sound.Button);
        
        Time.timeScale = 1f;
    }
}
