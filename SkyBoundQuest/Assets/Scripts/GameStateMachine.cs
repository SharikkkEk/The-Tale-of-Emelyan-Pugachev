using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates { walking, dialog };

public static class GameStateMachine
{
    public static GameStates state = GameStates.walking;
}

