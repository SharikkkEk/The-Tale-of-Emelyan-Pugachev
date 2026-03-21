using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates { walking, dialog };

// Автомат состояний игры
// Walking - игрок путешествует, dialog - игрок в диалоге
public static class GameStateMachine
{
    public static GameStates state = GameStates.walking;
}

