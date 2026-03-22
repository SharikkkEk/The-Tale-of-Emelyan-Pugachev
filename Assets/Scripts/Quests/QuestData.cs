using System.Collections.Generic;

[System.Serializable]
public class QuestData
{
    public string questName;
    public string description;
    public List<ChoiceData> choices;

    // для отладки
    public override string ToString()
    {
        return $"{questName}: {choices.Count} вариантов";
    }
}