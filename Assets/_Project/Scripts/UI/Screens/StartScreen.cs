using Firebase.Analytics;

public class StartScreen : UIScreen
{
    public void StartGame()
    {
        SoundManager.Instance.PlaySound(Sound.Button);

        Disable();

        UIManager.Instance.GameScreen.Enable();

        SpawnersManager.Instance.StartSpawning();

        FirebaseAnalytics.LogEvent("session_start");
        FirebaseAnalytics.LogEvent("current_color_(" + SavingSystem.Instance.Data.GameColorName + ")");
    }
}
