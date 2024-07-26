using UnityEngine;

public static class DataInitialization
{
    private const string Key = "TotalDataKey";

    private static MinigameCollection _minigameCollection;

    public static bool IsLoaded { get; private set; }

    public static void Load()
    {
        var rawString = PlayerPrefs.GetString(Key);
        _minigameCollection = JsonUtility.FromJson<MinigameCollection>(rawString);

        if (_minigameCollection == null)
        {
            _minigameCollection = new MinigameCollection();
        }

        IsLoaded = true;
    }

    public static void AddData(IMinigameData data)
    {
        _minigameCollection.AddData(data);
        Save();
    }

    public static T GetData<T>() where T : IMinigameData, new()
    {
        return _minigameCollection.GetData<T>();
    }

    public static void Save()
    {
        var rawString = JsonUtility.ToJson(_minigameCollection);
        PlayerPrefs.SetString(Key, rawString);
    }
}
