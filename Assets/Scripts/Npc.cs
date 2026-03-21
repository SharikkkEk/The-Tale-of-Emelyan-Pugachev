using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public abstract class Npc : MonoBehaviour
{
    protected Dialog _npcDialog = new Dialog();
    private bool playerIsNear;

    // Start is called before the first frame update
    void Start()
    {
        playerIsNear = false;
        loadDialog();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsNear && GameStateMachine.state == GameStates.walking)
        {
            if (Input.GetKeyDown(KeyCode.E))
            { 
                DialogManager.Instance.startDialog(_npcDialog);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerIsNear=true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") 
        {
            playerIsNear=false;
        }
    }

    protected abstract void loadDialog();
}
