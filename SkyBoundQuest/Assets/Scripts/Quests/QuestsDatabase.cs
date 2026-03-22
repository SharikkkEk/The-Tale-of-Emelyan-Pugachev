using System.Collections.Generic;

public static class AllQuests
{
    public static QuestData GetQuest(QuestID id)
    {
        switch (id)
        {
            case QuestID.FatherPunishment: return FatherPunishment();
            case QuestID.ColonelHorse: return ColonelHorse();
            case QuestID.Messenger: return Messenger();
            case QuestID.BathScene: return BathScene();
            case QuestID.CampFire: return CampFire();
            default: return null;
        }
    }

    // =========================
    // 1. ОТЦОВСКИЙ НАКАЗ
    // =========================
    private static QuestData FatherPunishment()
    {
        return new QuestData
        {
            QuestName = "Отцовский наказ",
            Description = "Отец отправил тебя собрать долг...",

            Choices = new List<ChoiceData>
            {
                new ChoiceData { Type = ChoiceType.Charisma, Text = "Попросить по-хорошему", Charisma = 1, CutsceneID = "father_charisma" },
                new ChoiceData { Type = ChoiceType.Greed, Text = "Запугать", Greed = 1, CutsceneID = "father_greed" },
                new ChoiceData { Type = ChoiceType.Determination, Text = "Стоять до конца", Determination = 1, CutsceneID = "father_determination" },
                new ChoiceData { Type = ChoiceType.Nobility, Text = "Помочь старухе", Nobility = 1, CutsceneID = "father_nobility" }
            }
        };
    }

    // =========================
    // 2. ЛОШАДЬ ПОЛКОВНИКА
    // =========================
    private static QuestData ColonelHorse()
    {
        return new QuestData
        {
            QuestName = "Полковничья лошадь",
            Description = "Ты потерял лошадь полковника...",

            Choices = new List<ChoiceData>
            {
                new ChoiceData { Type = ChoiceType.Charisma, Text = "Честно признаться", Charisma = 1, CutsceneID = "horse_charisma" },
                new ChoiceData { Type = ChoiceType.Greed, Text = "Свалить на другого", Greed = 1, CutsceneID = "horse_greed" },
                new ChoiceData { Type = ChoiceType.Determination, Text = "Умолять оставить в армии", Determination = 1, CutsceneID = "horse_determination" },
                new ChoiceData { Type = ChoiceType.Nobility, Text = "Взять вину на себя", Nobility = 1, CutsceneID = "horse_nobility" }
            }
        };
    }

    // =========================
    // 3. ХОДОК ОТ СТАНИЦЫ
    // =========================
    private static QuestData Messenger()
    {
        return new QuestData
        {
            QuestName = "Ходок от станицы",
            Description = "Казаки предлагают тебе отправиться в Петербург с жалобой...",

            Choices = new List<ChoiceData>
            {
                new ChoiceData { Type = ChoiceType.Charisma, Text = "Сделать печать для убедительности", Charisma = 1, CutsceneID = "messenger_charisma" },
                new ChoiceData { Type = ChoiceType.Greed, Text = "Потребовать больше денег", Greed = 1, CutsceneID = "messenger_greed" },
                new ChoiceData { Type = ChoiceType.Determination, Text = "Сразу отправиться в путь", Determination = 1, CutsceneID = "messenger_determination" },
                new ChoiceData { Type = ChoiceType.Nobility, Text = "Согласиться без выгоды ради людей", Nobility = 1, CutsceneID = "messenger_nobility" }
            }
        };
    }

    // =========================
    // 4. БАНЯ В ДОБРЯНКЕ
    // =========================
    private static QuestData BathScene()
    {
        return new QuestData
        {
            QuestName = "Баня в Добрянке",
            Description = "Тебя сравнили с императором Петром III...",

            Choices = new List<ChoiceData>
            {
                new ChoiceData { Type = ChoiceType.Charisma, Text = "Отшутиться и поговорить позже", Charisma = 1, CutsceneID = "bath_charisma" },
                new ChoiceData { Type = ChoiceType.Greed, Text = "Намекнуть на выгоду", Greed = 1, CutsceneID = "bath_greed" },
                new ChoiceData { Type = ChoiceType.Determination, Text = "Сразу объявить себя царем", Determination = 1, CutsceneID = "bath_determination" },
                new ChoiceData { Type = ChoiceType.Nobility, Text = "Отказаться от идеи", Nobility = 1, CutsceneID = "bath_nobility" }
            }
        };
    }

    // =========================
    // 5. РАЗГОВОР У КОСТРА
    // =========================
    private static QuestData CampFire()
    {
        return new QuestData
        {
            QuestName = "Разговор у костра",
            Description = "Пьянов жалуется на жизнь и ищет надежду...",

            Choices = new List<ChoiceData>
            {
                new ChoiceData { Type = ChoiceType.Charisma, Text = "Пообещать деньги позже", Charisma = 1, CutsceneID = "camp_charisma" },
                new ChoiceData { Type = ChoiceType.Greed, Text = "Пообещать богатства", Greed = 1, CutsceneID = "camp_greed" },
                new ChoiceData { Type = ChoiceType.Determination, Text = "Объявить себя царем", Determination = 1, CutsceneID = "camp_determination" },
                new ChoiceData { Type = ChoiceType.Nobility, Text = "Отговорить от бунта", Nobility = 1, CutsceneID = "camp_nobility" }
            }
        };
    }
}