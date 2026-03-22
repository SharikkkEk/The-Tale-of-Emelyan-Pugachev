public class NPCController : MonoBehaviour
{
    public QuestID questID;

    public void Interact()
    {
        QuestRunner.Instance.StartQuest(questID);
    }
}