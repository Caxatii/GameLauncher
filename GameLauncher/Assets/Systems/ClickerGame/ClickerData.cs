[System.Serializable]
public class ClickerData : IMinigameData
{
    private int _clicksCount;

    public ClickerData(int clicksCount = 0)
    {
        _clicksCount = clicksCount;
    }

    public string Name => "Clicker";

    public int ClicksCount => _clicksCount;
}
