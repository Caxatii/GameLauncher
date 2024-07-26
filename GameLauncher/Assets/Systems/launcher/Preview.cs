using UnityEngine;

[CreateAssetMenu(menuName ="Data/Create new Preview")]
public class Preview : ScriptableObject
{
    [SerializeField]
    private Sprite _sprite;

    [SerializeField]
    private string _gameName; 

    public Sprite Sprite => _sprite;
    public string GameName => _gameName;
}
