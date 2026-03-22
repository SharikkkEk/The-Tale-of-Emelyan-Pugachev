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
            questName = "Отцовский наказ",
            description = "Отец отправил тебя собрать долг у Федора Брыкалина. На площади ты видишь позорный столб — мир суров, долг превыше всего.",
            choices = new List<ChoiceData>
            {
                new ChoiceData {
                    type = ChoiceType.Charisma,
                    text = "Попросить по-хорошему: «Дядя Федор, община без моста пропадет. Помогите миром».",
                    charisma = 1, cutsceneID = "father_charisma"
                },
                new ChoiceData {
                    type = ChoiceType.Greed,
                    text = "Запугать атаманом: «Отдавай долг, Федор. Атаман велел, ослушаешься — позорный столб».",
                    greed = 1, cutsceneID = "father_greed"
                },
                new ChoiceData {
                    type = ChoiceType.Determination,
                    text = "Стоять до конца: «Я без денег не уйду. Хоть до вечера, хоть до утра — стой буду».",
                    determination = 1, cutsceneID = "father_determination"
                },
                new ChoiceData {
                    type = ChoiceType.Nobility,
                    text = "Помочь старухе: отдать деньги нищей у плетня, а долг отцу объяснить позже",
                    nobility = 1, cutsceneID = "father_nobility"
                }
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
            questName = "Полковничья лошадь",
            description = "Ночная тревога. Прусаки атаковали лагерь. Утром выяснилось: одна лошадь полковника пропала. Ты был в карауле.",
            choices = new List<ChoiceData>
            {
                new ChoiceData {
                    type = ChoiceType.Charisma,
                    text = "Честно признаться: «Виновен. Но ночью прусаки напали, лошади испугались. Разрешите вину в бою искупить».",
                    charisma = 1, cutsceneID = "horse_charisma"
                },
                new ChoiceData {
                    type = ChoiceType.Greed,
                    text = "Свалить на другого: «Это Степка-казак виноват, это он лошадей пугнул».",
                    greed = 1, cutsceneID = "horse_greed"
                },
                new ChoiceData {
                    type = ChoiceType.Determination,
                    text = "Умолять оставить в армии: «Накажите, но не гоните со службы! В бою за царя помереть хочу!»",
                    determination = 1, cutsceneID = "horse_determination"
                },
                new ChoiceData {
                    type = ChoiceType.Nobility,
                    text = "Взять вину на себя за молодого казака: «Я за старшего был, я и отвечаю».",
                    nobility = 1, cutsceneID = "horse_nobility"
                }
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
            questName = "Ходок от станицы",
            description = "Казаки на Тереке избрали тебя ходоком в Петербург. Нужно просить жалованье и провиант. Дело опасное.",
            choices = new List<ChoiceData>
            {
                new ChoiceData {
                    type = ChoiceType.Charisma,
                    text = "Сделать печать для убедительности: «Нужна печать посолиднее. Сделаем войсковую — комар носа не подточит».",
                    charisma = 1, cutsceneID = "messenger_charisma"
                },
                new ChoiceData {
                    type = ChoiceType.Greed,
                    text = "Потребовать больше денег: «Двадцать рублей — смех. Давайте тридцать, да коня получше».",
                    greed = 1, cutsceneID = "messenger_greed"
                },
                new ChoiceData {
                    type = ChoiceType.Determination,
                    text = "Сразу отправиться в путь: «Чего тянуть! Бумаги давайте, коня — и завтра в путь!»",
                    determination = 1, cutsceneID = "messenger_determination"
                },
                new ChoiceData {
                    type = ChoiceType.Nobility,
                    text = "Согласиться без выгоды ради людей: «Вижу вашу нужду. Пойду и денег лишних не возьму. За вас постою».",
                    nobility = 1, cutsceneID = "messenger_nobility"
                }
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
            questName = "Баня в Добрянке",
            description = "В бане беглый солдат Логачев говорит купцу Кожевникову: «Смотри, а ведь Емельян-то — вылитый император Петр Федорович!»",
            choices = new List<ChoiceData>
            {
                new ChoiceData {
                    type = ChoiceType.Charisma,
                    text = "Отшутиться и поговорить позже: «Типун тебе на язык!» — но бросить многозначительный взгляд на Кожевникова.",
                    charisma = 1, cutsceneID = "bath_charisma"
                },
                new ChoiceData {
                    type = ChoiceType.Greed,
                    text = "Намекнуть на выгоду: «Похож, говоришь? А если бы кто из купцов деньгами подсобил...»",
                    greed = 1, cutsceneID = "bath_greed"
                },
                new ChoiceData {
                    type = ChoiceType.Determination,
                    text = "Сразу объявить себя царем: «А что, верно! Будь что будет! Назовусь царем!»",
                    determination = 1, cutsceneID = "bath_determination"
                },
                new ChoiceData {
                    type = ChoiceType.Nobility,
                    text = "Отказаться от идеи: «Не болтай глупостей. Я человек подневольный, ищу место бога ради послужить».",
                    nobility = 1, cutsceneID = "bath_nobility"
                }
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
            questName = "Разговор у костра",
            description = "В доме казака Дениса Пьянова. Он жалуется на тяжелую жизнь и спрашивает: «А с чем нам бежать-то? Мы люди бедные...»",
            choices = new List<ChoiceData>
            {
                new ChoiceData {
                    type = ChoiceType.Charisma,
                    text = "Пообещать деньги позже: «Деньги у меня есть. Могу каждому казаку по двенадцати рублей дать. А откуда — скажу потом».",
                    charisma = 1, cutsceneID = "camp_charisma"
                },
                new ChoiceData {
                    type = ChoiceType.Greed,
                    text = "Пообещать богатства: «Мало двенадцати? А если скажу, что на границе двести тысяч и товару на семьдесят?»",
                    greed = 1, cutsceneID = "camp_greed"
                },
                new ChoiceData {
                    type = ChoiceType.Determination,
                    text = "Объявить себя царем: «Я не купец! Я — государь Петр Федорович! Чудом от смерти спасся!»",
                    determination = 1, cutsceneID = "camp_determination"
                },
                new ChoiceData {
                    type = ChoiceType.Nobility,
                    text = "Отговорить от бунта: «Не трави душу, Денис. Бежать — дело гиблое. Терпите, может, господь и пошлет заступника».",
                    nobility = 1, cutsceneID = "camp_nobility"
                }
            }
        };
    }
}