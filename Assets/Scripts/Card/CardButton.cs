using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CardButton : MonoBehaviour
{
    [Header("UI Components (assign in prefab)")]
    public TextMeshProUGUI choiceText;      // текст выбора
    public TextMeshProUGUI statEffectText;  // какой параметр повысится
    public Image cardBackground;             // фон карточки
    public Button button;                    // кнопка

    [Header("Colors")]
    public Color charismaColor = new Color(0.2f, 0.6f, 0.8f);    // голубой
    public Color greedColor = new Color(0.8f, 0.7f, 0.2f);        // золотой
    public Color determinationColor = new Color(0.8f, 0.3f, 0.2f); // красный
    public Color nobilityColor = new Color(0.3f, 0.7f, 0.4f);      // зеленый

    private ChoiceData choiceData;
    private int cardIndex;

    /// <summary>
    /// Инициализировать карточку данными выбора
    /// </summary>
    public void Initialize(ChoiceData choice, int index)
    {
        choiceData = choice;
        cardIndex = index;

        // текст выбора
        if (choiceText != null)
            choiceText.text = choice.text;

        // текст эффекта (какая черта повысится)
        if (statEffectText != null)
            statEffectText.text = GetStatEffectText(choice);

        // цвет фона в зависимости от типа
        if (cardBackground != null)
            cardBackground.color = GetColorByType(choice.type);

        // настройка кнопки
        if (button != null)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(OnClick);
        }
    }

    /// <summary>
    /// Получить текст о повышении черты
    /// </summary>
    private string GetStatEffectText(ChoiceData choice)
    {
        switch (choice.type)
        {
            case ChoiceType.Charisma:
                return "+1 Харизма";
            case ChoiceType.Greed:
                return "+1 Корысть";
            case ChoiceType.Determination:
                return "+1 Решимость";
            case ChoiceType.Nobility:
                return "+1 Благородство";
            default:
                return "";
        }
    }

    /// <summary>
    /// Получить цвет по типу выбора
    /// </summary>
    private Color GetColorByType(ChoiceType type)
    {
        switch (type)
        {
            case ChoiceType.Charisma: return charismaColor;
            case ChoiceType.Greed: return greedColor;
            case ChoiceType.Determination: return determinationColor;
            case ChoiceType.Nobility: return nobilityColor;
            default: return Color.white;
        }
    }

    /// <summary>
    /// Обработка нажатия
    /// </summary>
    private void OnClick()
    {
        // анимация нажатия
        StartCoroutine(AnimateClick());

        // уведомляем контроллер о выборе
        CardUIController.Instance?.OnChoiceSelected(choiceData);
    }

    /// <summary>
    /// Анимация нажатия
    /// </summary>
    private System.Collections.IEnumerator AnimateClick()
    {
        Vector3 originalScale = transform.localScale;
        transform.localScale = originalScale * 0.95f;
        yield return new WaitForSeconds(0.05f);
        transform.localScale = originalScale;
    }
}