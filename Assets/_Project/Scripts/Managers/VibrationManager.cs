using System.Collections;
using UnityEngine;

public class VibrationManager : Singleton<VibrationManager>
{
    private bool isVibrate = false;

    private void Update()
    {
        if (isVibrate)
            Handheld.Vibrate();
    }

    public void PlayVibration()
    {
        Handheld.Vibrate();
    }

    public void PlayVibration(float time)
    {
        StartCoroutine(VibrationRoutine(time));
    }

    private IEnumerator VibrationRoutine(float time)
    {
        isVibrate = true;
        yield return new WaitForSecondsRealtime(time);
        isVibrate = false;
    }
}
