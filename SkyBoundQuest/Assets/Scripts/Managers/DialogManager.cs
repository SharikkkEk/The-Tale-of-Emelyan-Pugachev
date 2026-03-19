using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    DialogState currentState;

    public void toNextState(int choice)
    {
        currentState = currentState.tablePerehodov[choice];
        DialogGui.showDialogState(currentState);
    }   

    public void StartDialog(Dialog dialog)
    {
        currentState = dialog.states[0];
        DialogGui.showDialogState(currentState);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

private class DialogGui : MonoBehaviour
{
    private enum states { choice; player; npc; inactive }

    states state;

    int choice;

    public GameObject dialogBar;
    public GameObject playerBar;
    public GameObject npcBar;

    public Text choices;
    public Text charText;
    public Text npcText;

    void Start()
    {e
        state = states.inactive;
        dialogBar.SetActive(false);
        playerBar.SetActive(false);
        npcBar.SetActive(false);
    }

    void Update()
    {
        switch (state)
        {
            case states.choice:
                if (Input.GetKeyDown(KeyCode.R))
                {
                    dialogBar.SetActive(false);
                    choice = 0;
                    showCharWords();
                }
                else if (Input.GetKeyDown(KeyCode.E))
                {
                    dialogBar.SetActive(false);
                    choice = 1;
                    showCharWords();
                }     
                break;
            case states.player:
                if (Input.GetKeyDown(KeyCode.E))
                {
                    showNpcWords();
                }
            case states.npc:
                if (Input.GetKeyDown(KeyCode.E))
                {
                    DialogManager.toNextState(choice);
                }
            default:
                break;
        }
    }

    public void showDialogState(DialogState dialogState)
    {
        string choicesString;

        for (int i = 0; i < dialogState.states.Length; i++)
        {
            choicesString += dialogState.phrases[i].text;
        }

        choices.text = choicesString;
        dialogBar.setActive(true);

        state = states.choice;
    }

    private void showCharWords(string words)
    {
        charText.text = words;
        state = states.player;
    }

    private void showNpcWords(string words)
    {
        npcText.text = words;

        state = states.npc;
    }
}