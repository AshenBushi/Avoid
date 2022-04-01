using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SavingSystem : Singleton<SavingSystem>
{
    private string _path;

    public Data Data;

    protected override void Awake()
    {
        MakeGlobal();

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

[Serializable]
public class Data
{
    public Color UIColor;
    public Color PlayerColor;
    public ShopData Shop;
    public string UIColorName;
    public int BestScore;
    public int DeathCount;
    public int Money;
    public int CurSelectedCharacterIndex;
    public int CurSelectedCharacterColorIndex;
    public int CurSelectedGameColorIndex;
    public int CurSelectedBackgroundIndex;
    public bool VolumeState;

    public Data()
    {
        VolumeState = true;
        BestScore = 0;
        DeathCount = 0;
        UIColor = Color.green;
        PlayerColor = Color.green;
        UIColorName = "Green";
        Money = 0;

        CurSelectedCharacterIndex = 0;
        CurSelectedCharacterColorIndex = 0;
        CurSelectedGameColorIndex = 0;
        CurSelectedBackgroundIndex = 0;

        Shop.OpenedCharacters = new List<int>()
        {
            0
        };

        Shop.OpenedCharacterColors = new List<int>()
        {
            0
        };

        Shop.OpenedGameColors = new List<int>()
        {
            0
        };

        Shop.OpenedBackgrounds = new List<int>()
        {
            0
        };
    }
}

[Serializable]
public struct ShopData
{
    public List<int> OpenedCharacters;
    public List<int> OpenedCharacterColors;
    public List<int> OpenedGameColors;
    public List<int> OpenedBackgrounds;
}
