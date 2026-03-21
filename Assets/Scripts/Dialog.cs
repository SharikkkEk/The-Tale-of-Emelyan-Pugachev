using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog
{
    private List<DialogState> states;

    public void load(List<DialogState> loadedStates)
    {
        // Временное решение загрузки состояний диалога
        // TODO: сделать загрузку из файла
        states = loadedStates;
    }
    
    public DialogState firstState() => states[0];
}

// Состояние диалога
/*
 * Диалог выглядит так:
 * |----------|
 * |1. Hello  |
 * |2. Bye    |
 * |----------|
 * Этот квадратик - DialogState, состояние диалога
 * Игрок выбирает 1 строчку - мы находим следующее состояние в словаре и переходим к нему
 */
public class DialogState
{
    private List<Phrase> _phrases; // Список всех фраз
    // Ключ словаря - int, номер выбранной фразы. В зависимости от этого номера и переходим к следующему DialogState
    private Dictionary<int, DialogState> _transitionTable = new Dictionary<int, DialogState>(); 

    public DialogState(List<Phrase> phrases) { _phrases = phrases; }

    public DialogState getNextState(int n)
    {
        // Ищем в словаре следующее состояние
        if (_transitionTable.ContainsKey(n))
        {
            return _transitionTable[n];
        }
        return null;
    }

    public string getStringOfVariants() 
    {
        // Функция для удобства. Возвращает всевозможные варианты выбора в этом состоянии диалога
        string str = "";
        for (int i = 0; i < _phrases.Count; i++)
        {
            str += $"{i + 1}. {_phrases[i].getCharText()}\n";
        }
        return str;
    }

    public void loadTable(List<DialogState> stateList)
    {
        // Временное решение, сделаем потом загрузку из файла
        // TODO: сделать загрузку из файла
        for (int i = 0; i < stateList.Count; ++i)
        {
           _transitionTable[i] = stateList[i];   
        }
    }

    public Phrase getPhrase(int i) => _phrases[i];
}

public class Phrase
{
    // Фраза состоит из слов персонажа и npc(логично пиздец)
    private string _charText;
    private string _npcAnswer;

    public string getCharText() { return _charText; }
    public string getNpcAnswer() { return _npcAnswer; }

    public Phrase(string charText, string npcAnswer) { _charText = charText; _npcAnswer = npcAnswer;}
}