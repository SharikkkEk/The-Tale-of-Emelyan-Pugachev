using UnityEngine;

public class QuestRunner : MonoBehaviour
{
    public static QuestRunner Instance;

    [Header("Stats")]
    public int charismaPoints;
    public int greedPoints;
    public int determinationPoints;
    public int nobilityPoints;

    private QuestData currentQuest;
    private int currentQuestIndex;
    private QuestID[] questOrder = new QuestID[]
    {
        QuestID.FatherPunishment,
        QuestID.ColonelHorse,
        QuestID.Messenger,
        QuestID.BathScene,
        QuestID.CampFire
    };

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        StartQuest(questOrder[0]);
    }

    public void StartQuest(QuestID id)
    {
        currentQuest = AllQuests.GetQuest(id);
        currentQuestIndex = System.Array.IndexOf(questOrder, id);

        // показать UI с квестом
        CardUIController.Instance.ShowQuest(currentQuest);
    }

    public void MakeChoice(ChoiceData choice)
    {
        // начисляем очки
        charismaPoints += choice.charisma;
        greedPoints += choice.greed;
        determinationPoints += choice.determination;
        nobilityPoints += choice.nobility;

        // воспроизводим катсцену-эпилог
        CutscenePlayer.Instance.Play(choice.cutsceneID);

        // переходим к следующему квесту или завершаем акт
        int nextIndex = currentQuestIndex + 1;
        if (nextIndex < questOrder.Length)
        {
            StartQuest(questOrder[nextIndex]);
        }
        else
        {
            EndAct1();
        }
    }

    private void EndAct1()
    {
        // определяем доминирующую черту
        var dominant = GetDominantStat();

        // сохраняем результат и переходим к Акту 2
        GameState.Instance.SetAct1Result(dominant,
            charismaPoints, greedPoints, determinationPoints, nobilityPoints);

        SceneManager.LoadScene("Act2_Map");
    }

    private ChoiceType GetDominantStat()
    {
        // можно реализовать логику определения доминирующей черты
        // например, та, у которой больше всего очков
        // при равенстве — учитываем последний выбор или случайность
    }
}