using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestBase : MonoBehaviour
{
    TestInputActions testInputAction;


    private void Awake()
    {
        testInputAction = new TestInputActions();
    }

    private void OnEnable()
    {
        testInputAction.Enable();
        testInputAction.Test.Test1.performed += OnTest1;
        testInputAction.Test.Test2.performed += OnTest2;
        testInputAction.Test.Test3.performed += OnTest3;
        testInputAction.Test.Test4.performed += OnTest4;
        testInputAction.Test.Test5.performed += OnTest5;
        testInputAction.Test.Test6.performed += OnTest6;
        testInputAction.Test.Test7.performed += OnTest7;
        testInputAction.Test.Test8.performed += OnTest8;
    }

    private void OnDisable()
    {
        testInputAction.Test.Test8.performed -= OnTest8;
        testInputAction.Test.Test7.performed -= OnTest7;
        testInputAction.Test.Test6.performed -= OnTest6;
        testInputAction.Test.Test5.performed -= OnTest4;
        testInputAction.Test.Test4.performed -= OnTest3;
        testInputAction.Test.Test3.performed -= OnTest2;
        testInputAction.Test.Test2.performed -= OnTest5;
        testInputAction.Test.Test1.performed -= OnTest1;
        testInputAction.Disable();
    }
    protected virtual void OnTest8(InputAction.CallbackContext obj)
    {
    }
    protected virtual void OnTest7(InputAction.CallbackContext context)
    {
    }
    protected virtual void OnTest6(InputAction.CallbackContext context)
    {
    }
    protected virtual void OnTest5(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTest4(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTest3(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTest2(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTest1(InputAction.CallbackContext context)
    {
    }
}
