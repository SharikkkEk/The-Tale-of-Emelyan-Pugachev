using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    DialogState currentState;
    public static DialogManager Instance = null;

    public void toNextState(int choice)
    {
        currentState = currentState.getNextState(choice);
        if (currentState != null)
        {
            DialogGui.Instance.showDialogState(currentState);
        }
        else
        {
            GameStateMachine.state = GameStates.walking;
        }
    }   

    public void startDialog(Dialog dialog)
    {
        GameStateMachine.state = GameStates.dialog;
        currentState = dialog.firstState();
        DialogGui.Instance.showDialogState(currentState);
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        currentState = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

