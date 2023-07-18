using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public UnityEvent OnPunch;

    //public DestructibleObject target;

    [SerializeField] private Collider2D _toolCollider;
    [SerializeField] private ContactFilter2D[] _filters;

    [SerializeField] private int _dealtDamaage = 20;

    public void Punch(InputAction.CallbackContext context)
    {
        if( context.performed )
        {
            //Animation hookup and sth like this
            OnPunch?.Invoke();

            Collider2D[] colliders = new Collider2D[10];
            int num = Physics2D.OverlapCollider(_toolCollider, _filters[0], colliders);
            if (num > 0)
            {
                foreach (var item in colliders)
                {
                    if (item != null)
                    {
                        Debug.Log("Hit " + item);
                        if (item.gameObject.TryGetComponent<DestructibleObject>(out var component))
                        {
                            component.Hit(_dealtDamaage);
                        }

                    }
                }
            }
            else
            {
                Debug.Log("No hit!");
            }
        }
    }
}
