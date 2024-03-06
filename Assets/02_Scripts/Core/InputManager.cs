using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    public static InputManager Instance
    {
        get { return instance; }
    }

    private PlayerInputActions inputActions;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        inputActions = new PlayerInputActions();

        //Cursor.visible = false;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
        public Vector2 GetPlayerMovement()
        {
            return inputActions.Player.Move.ReadValue<Vector2>();
        }
        public Vector2 GetMousDelta()
        {
            return inputActions.Player.Look.ReadValue<Vector2>();
        }

}
