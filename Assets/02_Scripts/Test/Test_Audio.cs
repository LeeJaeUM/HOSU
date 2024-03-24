using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Audio : TestBase
{
    public AudioManager audioManager;
    protected override void OnTest1(InputAction.CallbackContext context)
    {
        audioManager.PlaySfx(AudioManager.Sfx.Knock);
    }
    protected override void OnTest2(InputAction.CallbackContext context)
    {
        audioManager.PlaySfx(AudioManager.Sfx.Knock_Power);
    }
    protected override void OnTest3(InputAction.CallbackContext context)
    {
        audioManager.PlaySfx(AudioManager.Sfx.Choke);
    }
    protected override void OnTest4(InputAction.CallbackContext context)
    {
        audioManager.PlaySfx(AudioManager.Sfx.SellPhone);

    }
    protected override void OnTest5(InputAction.CallbackContext context)
    {
        audioManager.PlaySfx(AudioManager.Sfx.Bell);
    }
}
