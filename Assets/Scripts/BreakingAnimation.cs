using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BreakingAnimation: MonoBehaviour
{
    private Animator animator;
    private DestructibleObject destructible;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        destructible = GetComponent<DestructibleObject>();
    }

    public void OnDamaged()
    {
        float factor = (float)destructible.GetHealth() / (float)destructible.GetHealthMax();
        animator.SetFloat("health", factor);
    }
}
