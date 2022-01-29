using Firebase.Analytics;

public class StartScreen : UIScreen
{
    public void StartGame()
    {
        SoundManager.Instance.PlaySound(Sound.Button);

        Hide();

        UIManager.Instance.GameScreen.Show();

        SpawnersManager.Instance.StartSpawning();

        FirebaseAnalytics.LogEvent("session_start");
        FirebaseAnalytics.LogEvent("current_color_(" + SavingSystem.Instance.Data.GameColorName + ")");
    }
}
