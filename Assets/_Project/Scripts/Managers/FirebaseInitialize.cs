using Firebase;
using Firebase.Extensions;
using UnityEngine;

public class FirebaseInitialize : MonoBehaviour
{
    private void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            var app = FirebaseApp.DefaultInstance;
        });
    }
}
