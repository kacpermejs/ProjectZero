using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public UnityEvent OnPunch;

    public DestructibleObject target;

    public void Punch(InputAction.CallbackContext context)
    {
        if( context.performed )
        {
            target.Hit(34);
            OnPunch?.Invoke();
        }
    }
}
