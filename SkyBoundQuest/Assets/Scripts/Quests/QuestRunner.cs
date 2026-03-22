public class QuestRunner : MonoBehaviour
{
    public static QuestRunner Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void StartQuest(QuestID id)
    {
        var quest = AllQuests.GetQuest(id);

        CardUIController.Instance.ShowQuest(quest);
    }
}