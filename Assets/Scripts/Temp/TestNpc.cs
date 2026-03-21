using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNPC : Npc
{
    protected override void loadDialog()
    {
        DialogState start = new DialogState
        (
            new List<Phrase> { 
                new Phrase("Hello", "Hi"),
                new Phrase("Bye", "bye")
            }
        );

        DialogState mid = new DialogState
        (
            new List<Phrase> { 
                new Phrase("How are you?", "fine"),
                new Phrase("Bye", "bye")
            }
        );

        start.loadTable(new List<DialogState> { mid });

        _npcDialog.load(new List<DialogState> { start, mid });
    }
}
