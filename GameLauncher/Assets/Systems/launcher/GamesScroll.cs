using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class GamesScroll : MonoBehaviour
{
    private const string Path = "Previews";

    [SerializeField]
    private MinigamePreview _minigamePrefab;
    private List<MinigamePreview> _minigameCollection;

    private Preview[] _previews;

    private ScrollRect _scrollRect;

    private void OnEnable()
    {
        _minigameCollection = new List<MinigamePreview>();

        _scrollRect = GetComponent<ScrollRect>();
        LoadMinigamePreviews();
    }



    private void LoadMinigamePreviews()
    {
        _previews = Resources.LoadAll<Preview>(Path);

        foreach (var preview in _previews)
        {
            AddMinigame(preview); 
        }
    }

    public void AddMinigame(Preview preview)
    {
        var miniGame = Instantiate(_minigamePrefab, _scrollRect.content);

        miniGame.Init(preview.Sprite, preview.GameName, true);

        _minigameCollection.Add(miniGame);
    }
}
