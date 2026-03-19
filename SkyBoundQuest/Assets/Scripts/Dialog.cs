using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Игрок нажимает e -> npc это замечает, вызывает событие, на которое подписан DialogManager
Снизу появляется бар с выбором реплик. Каждый выбор реплик - dialogState. При выборе реплике показываетс слова персонажа, на него отвечает нпс
Переходит переход в следующий DialogState при помощи хеш таблицы конкретной dialogState. 
*/

public class Dialog : MonoBehaviour
{
    List<DialogState> states;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class DialogState : MonoBehaviour
{
    List<Phrase> phrases;
    Dictionary<int, DialogState> tablePerehodov;
}

public class Phrase : MonoBehaviour
{
    public string text;
    public string otvet;
}