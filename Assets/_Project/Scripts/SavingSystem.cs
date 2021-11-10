using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SavingSystem : Singleton<SavingSystem>
{
    private string _path;
    
    public Data Data;
    
    protected override void Awake()
    {
        base.Awake();

        Load();
    }

    private void Load()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _path = Path.Combine(Application.persistentDataPath, "Data.json");
#else
        _path = Path.Combine(Application.dataPath, "Data.json");
#endif

        if (File.Exists(_path))
        {
            Data = JsonUtility.FromJson<Data>(File.ReadAllText(_path));
        }
        else
        {
            Data = new Data();
            Save();
        }
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        Save();
    }
#endif
    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        File.WriteAllText(_path, JsonUtility.ToJson(Data));
    }
}

public class Data
{
    public bool SoundState;
    public int BestScore;

    public Data()
    {
        SoundState = true;
        BestScore = 0;
    }
}