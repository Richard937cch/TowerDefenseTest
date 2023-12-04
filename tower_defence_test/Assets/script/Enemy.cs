using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 150;

    PlayerState playerState;

    Animator animator;

    void Awake()
    {
        playerState = GameObject.Find("playerState").GetComponent<PlayerState>();
        //animator = GameObject.Find("Mini simple Characters Animation Controller Demo").GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (hp <= 0) return;
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //animator.SetBool("Mini Simple Characters Armature|Walk",false);
        //animator.SetBool()
        Destroy(this.gameObject);
        playerState.enemyTotal -= 1;
    }
}
