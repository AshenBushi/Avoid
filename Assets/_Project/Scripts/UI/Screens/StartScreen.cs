using Firebase.Analytics;
using System;

public class StartScreen : UIScreen
{
    public static Action OnGameStart;

    public void StartGame()
    {
        SoundManager.Instance.PlaySound(Sound.Button);

        Disable();

        UIManager.Instance.GameScreen.Enable();

        SpawnersManager.Instance.StartSpawning();

        FirebaseAnalytics.LogEvent("session_start");
        FirebaseAnalytics.LogEvent("current_color_(" + SavingSystem.Instance.Data.UIColorName + ")");

        OnGameStart?.Invoke();
    }
}
