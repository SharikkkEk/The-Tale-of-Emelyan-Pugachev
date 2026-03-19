using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class Npc : MonoBehaviour
{
    public GameObject panel;
    string text = "Hello";
    public Text dialog;
    private bool playerIsNear;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        playerIsNear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialog.text = text;
                panel.SetActive(true);
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
            panel.SetActive(false);
        }
    }
}
