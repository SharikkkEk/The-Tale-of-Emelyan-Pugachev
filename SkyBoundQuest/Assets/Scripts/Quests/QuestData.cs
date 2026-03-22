using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Game/Quest")]
public class QuestData : ScriptableObject
{
    public string questName;
    [TextArea] public string description;

    public List<ChoiceData> choices;
}