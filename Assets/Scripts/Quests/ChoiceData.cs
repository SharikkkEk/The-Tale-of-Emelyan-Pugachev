using UnityEngine;

[System.Serializable]
public class ChoiceData
{
    public ChoiceType type;
    [TextArea(2, 4)] public string text;

    // что дает выбор
    public int charisma;
    public int greed;
    public int determination;
    public int nobility;

    public string cutsceneID;

    // удобный метод для получения значения по типу
    public int GetStatValue(ChoiceType t)
    {
        switch (t)
        {
            case ChoiceType.Charisma: return charisma;
            case ChoiceType.Greed: return greed;
            case ChoiceType.Determination: return determination;
            case ChoiceType.Nobility: return nobility;
            default: return 0;
        }
    }
}