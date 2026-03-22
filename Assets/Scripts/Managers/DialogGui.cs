using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Управление Диалогом
public class DialogGui : MonoBehaviour
{
    public static DialogGui Instance = null;

    private DialogState _dialogState;
    // 4 состояния - выбор фразы, слова персонажа, слова нпс и отсутствие диалога(inactive)
    private enum states { choice, player, npc, inactive }

    states state;

    int choice;

    // 3 отдельные панели для основного диалога(dialogBar), слов персонажа и нпс
    public GameObject dialogBar;
    public GameObject playerBar;
    public GameObject npcBar;

    public Text charText;
    public Text npcText;
    public Text choices;

    void Start()
    {
        Instance = this; // Необходимо для того, чтобы можно было в коде обратиться к классу
        _dialogState = null; // Текущего состояния нет
        state = states.inactive;
        dialogBar.SetActive(false);
        playerBar.SetActive(false);
        npcBar.SetActive(false);
    }

    void Update()
    {
        // Автомат состояний
        // Обрабатываем нажатия в зависимости от того, в каком состоянии находится диалог
        switch (state)
        {
            case states.choice:
                // Временное решение: R - выбор 1 строчки, E - выбор 2
                // TODO: сделать адекватное управление
                if (Input.GetKeyDown(KeyCode.R))
                {
                    // Игрок выбирает строчку, показывается слова персонажа
                    choice = 0;
                    showCharWords();
                    state = states.player; // Диалог переходит в новое состояние
                }
                else if (Input.GetKeyDown(KeyCode.E))
                {
                    choice = 1;
                    showCharWords();
                    state = states.player;
                }
                else if (Input.GetKeyDown(KeyCode.Escape)) // В любой момент можно выйти из диалога
                {
                    state = states.inactive;
                    dialogBar.SetActive(false);
                    GameStateMachine.state = GameStates.walking;
                }
                break;
            case states.player:
                // Ждём, пока игрок нажмёт E. После этого показываем слова NPC
                if (Input.GetKeyDown(KeyCode.E))
                {
                    showNpcWords();
                    state = states.npc;
                }
                break;
            case states.npc:
                if (Input.GetKeyDown(KeyCode.E))
                {
                    state = states.choice;
                    npcBar.SetActive(false);
                    DialogManager.Instance.toNextState(choice); // Переход к новому состоянию диалога
                }
                break;
            default:
                break;
        }
    }

    public void showDialogState(DialogState dialogState)
    {
        _dialogState = dialogState;
        choices.text = _dialogState.getStringOfVariants();
        dialogBar.SetActive(true);
        state = states.choice;
    }

    private void showCharWords()
    {
        dialogBar.SetActive(false);
        charText.text = _dialogState.getPhrase(choice).getCharText();
        playerBar.SetActive(true);
    }

    private void showNpcWords()
    {
        playerBar.SetActive(false);
        npcText.text = _dialogState.getPhrase(choice).getNpcAnswer();
        npcBar.SetActive(true);
    }
}