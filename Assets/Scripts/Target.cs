using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public Animator animator;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();

        }
    }
    public void Die()
    {
        animator.Play("Z_FallingBack");
    }
}
