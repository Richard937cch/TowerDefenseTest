using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 150;

    PlayerState playerState;

    Animator animator;
    float timer=0;

    void Awake()
    {
        playerState = GameObject.Find("playerState").GetComponent<PlayerState>();
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("Walk",false);
    }

    public void TakeDamage(int damage)
    {
        //if (hp <= 0) return;
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("Walk",true);
        //animator.SetBool()
        
        
        
        //Destroy(this.gameObject);
        //playerState.enemyTotal -= 1;
    }

    void Update()
    {
        if (hp <= 0)
        {
            timer += Time.deltaTime;
            var step =  1.0f * Time.deltaTime;
            Vector3 fallpos = transform.position;
            fallpos[1] -= -3.0f;
            transform.position = Vector3.MoveTowards(transform.position, fallpos, step);
            if (timer >= 0.5f)
            {
                Destroy(this.gameObject);
                playerState.enemyTotal -= 1;
            }
        }
            
    }
}
