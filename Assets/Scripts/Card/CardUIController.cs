using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro; // если используешь TextMeshPro, иначе убери

public class CardUIController : MonoBehaviour
{
    public static CardUIController Instance;

    [Header("UI References")]
    public GameObject cardPanel;           // панель, на которой появляются карточки
    public Transform cardContainer;        // контейнер для карточек (например, GridLayoutGroup)
    public GameObject cardPrefab;          // префаб карточки выбора

    [Header("Quest Display")]
    public TextMeshProUGUI questNameText;  // название квеста
    public TextMeshProUGUI questDescText;  // описание квеста

    [Header("Animation")]
    public float cardAppearDelay = 0.1f;   // задержка между появлением карточек
    public float cardAppearDuration = 0.3f; // длительность анимации появления

    [Header("Settings")]
    public bool autoHideOnChoice = true;    // скрывать ли панель после выбора

    private QuestData currentQuest;
    private List<GameObject> activeCards = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // скрываем панель при старте
        if (cardPanel != null)
            cardPanel.SetActive(false);
    }

    /// <summary>
    /// Показать квест с карточками выбора
    /// </summary>
    public void ShowQuest(QuestData quest)
    {
        currentQuest = quest;

        // очищаем старые карточки
        ClearCards();

        // показываем панель
        cardPanel.SetActive(true);

        // обновляем текст квеста
        if (questNameText != null)
            questNameText.text = quest.questName;
        if (questDescText != null)
            questDescText.text = quest.description;

        // создаем карточки
        StartCoroutine(CreateCardsWithDelay());
    }

    /// <summary>
    /// Создать карточки с задержкой (эффект появления)
    /// </summary>
    private System.Collections.IEnumerator CreateCardsWithDelay()
    {
        for (int i = 0; i < currentQuest.choices.Count; i++)
        {
            CreateCard(currentQuest.choices[i], i);
            yield return new WaitForSeconds(cardAppearDelay);
        }
    }

    /// <summary>
    /// Создать одну карточку
    /// </summary>
    private void CreateCard(ChoiceData choice, int index)
    {
        GameObject cardObj = Instantiate(cardPrefab, cardContainer);
        CardButton cardButton = cardObj.GetComponent<CardButton>();

        if (cardButton == null)
            cardButton = cardObj.AddComponent<CardButton>();

        // настраиваем карточку
        cardButton.Initialize(choice, index);

        // анимация появления
        cardObj.transform.localScale = Vector3.zero;
        StartCoroutine(AnimateCardAppear(cardObj));

        activeCards.Add(cardObj);
    }

    /// <summary>
    /// Анимация появления карточки
    /// </summary>
    private System.Collections.IEnumerator AnimateCardAppear(GameObject card)
    {
        float elapsed = 0;
        Vector3 startScale = Vector3.zero;
        Vector3 targetScale = Vector3.one;

        while (elapsed < cardAppearDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / cardAppearDuration;
            card.transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }

        card.transform.localScale = targetScale;
    }

    /// <summary>
    /// Обработка выбора игрока
    /// </summary>
    public void OnChoiceSelected(ChoiceData choice)
    {
        if (autoHideOnChoice)
            HideCards();

        // передаем выбор в QuestRunner
        QuestRunner.Instance?.MakeChoice(choice);
    }

    /// <summary>
    /// Скрыть все карточки
    /// </summary>
    public void HideCards()
    {
        ClearCards();
        if (cardPanel != null)
            cardPanel.SetActive(false);
    }

    /// <summary>
    /// Очистить все карточки
    /// </summary>
    private void ClearCards()
    {
        foreach (GameObject card in activeCards)
        {
            if (card != null)
                Destroy(card);
        }
        activeCards.Clear();
    }

    /// <summary>
    /// Обновить квест (если нужно показать новый)
    /// </summary>
    public void RefreshQuest(QuestData newQuest)
    {
        HideCards();
        ShowQuest(newQuest);
    }
}