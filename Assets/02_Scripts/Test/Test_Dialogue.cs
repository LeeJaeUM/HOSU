using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Dialogue : TestBase
{
    public DialogueManager dialogueManager;
    

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        GameManager.Inst.Dia2End();
    }
    protected override void OnTest2(InputAction.CallbackContext context)
    {
        dialogueManager.SpeakDialogue(2);

    }
    protected override void OnTest3(InputAction.CallbackContext context)
    {
        dialogueManager.SpeakDialogue(3);

    }
    protected override void OnTest4(InputAction.CallbackContext context)
    {
        dialogueManager.SpeakDialogue(4);

    }
    protected override void OnTest5(InputAction.CallbackContext context)
    {
        dialogueManager.SpeakDialogue(5);

    }
    protected override void OnTest6(InputAction.CallbackContext context)
    {
        dialogueManager.SpeakDialogue(6);

    }
    protected override void OnTest7(InputAction.CallbackContext context)
    {
        dialogueManager.SpeakDialogue(7);

    }
    protected override void OnTest8(InputAction.CallbackContext context)
    {
        dialogueManager.SpeakDialogue(8);

    }

}
