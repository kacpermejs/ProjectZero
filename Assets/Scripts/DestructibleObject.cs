using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestructibleObject : MonoBehaviour
{
    public UnityEvent destructionCallback;
    public UnityEvent hitCallback;


    [SerializeField] private int maxHealth = 100;
    
    private int health;

    private void Awake()
    {
        health = maxHealth; 
    }

    public void Hit(int damage)
    {
        Debug.Log("Hit by " + damage);
        if (health <= damage)
        {
            health = 0;
            Debug.Log("Destroyed");
            OnObjectDestroyed();
        }
        else
        {
            health -= damage;
            OnObjectHit();
        }
    }

    private void OnObjectHit()
    {
        hitCallback?.Invoke();
    }

    private void OnObjectDestroyed()
    {
        destructionCallback?.Invoke();
    }

    public int GetHealth() { return health; }
    public int GetHealthMax() { return maxHealth; }
}
