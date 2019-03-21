using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    ZombieHealth zombieHealth;
    bool playerInRange;
    float timer;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        zombieHealth = GetComponent<ZombieHealth>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter (Collider other)
    {
        // laetur zombie attack-a player ef hann er i range og zombie er ekki daudur
        if(other.gameObject == player && zombieHealth.currentHealth > 0)
        {
            playerInRange = true;
            anim.SetBool("IsAttacking", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // laetur zombie haetta ad attack-a player thegar hann fer out of range
        if(other.gameObject == player)
        {
            playerInRange = false;
            anim.SetBool("IsAttacking", false);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange && zombieHealth.currentHealth >0)
        {
            Attack();
        }

        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
            anim.SetBool("IsAttacking", false);
        }
    }

    void Attack()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
