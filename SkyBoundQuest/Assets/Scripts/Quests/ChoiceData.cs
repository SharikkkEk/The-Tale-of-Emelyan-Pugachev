using UnityEngine;

[System.Serializable]
public class ChoiceData
{
    public ChoiceType type;
    [TextArea] public string text;

    // что дает выбор
    public int charisma;
    public int greed;
    public int determination;
    

    public string cutsceneID;
}