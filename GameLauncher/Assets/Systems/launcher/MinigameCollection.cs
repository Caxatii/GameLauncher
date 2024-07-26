using System;
using System.Collections.Generic;

[System.Serializable]
public class MinigameCollection
{
    private List<IMinigameData> _collection;
    private Dictionary<Type, IMinigameData> _minigameMap;

    public void AddData(IMinigameData data)
    {
        UpdateMinigameMap();

        var type = data.GetType();

        if(_minigameMap.ContainsKey(type))
        {
            _minigameMap[type] = data;
        }
        else
        {
            _minigameMap.Add(type, data);
        }

        Save();
    }

    public T GetData<T>() where T : IMinigameData, new()
    {
        var type = typeof(T);
        if (_minigameMap.ContainsKey(type)) return (T)_minigameMap[type];
        return new T();
    }

    private void UpdateMinigameMap()
    {
        _minigameMap = new Dictionary<Type, IMinigameData>();

        foreach(var item in _collection)
        {
            var type = item.GetType();
            if(_minigameMap.ContainsKey(type))
            { 
                _minigameMap[type] = item; 
                return;
            }
            _minigameMap.Add(type, item);
        }
    }

    private void Save()
    {
        _collection = new List<IMinigameData>();
        foreach (var item in _minigameMap)
        {
            _collection.Add(item.Value);
        }
    }
}
