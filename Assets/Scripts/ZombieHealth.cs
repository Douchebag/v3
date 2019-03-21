using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 0.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;

    Animator anim;
    AudioSource zombieAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    void Awake()
    {
        anim = GetComponent<Animator>();
        zombieAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;
    }

    void Update()
    {
        if(isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }
    
    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        // tekur health fra zombie ef hann er enntha lifandi og spilar sound effect
        // ef zombie deyr kallar fallid i Death fallid
        if (isDead)
            return;

        zombieAudio.Play();

        currentHealth -= amount;

        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger("Dead");

        zombieAudio.clip = deathClip;
        zombieAudio.Play();
    }

    public void StartSinking()
    {
        // letur zombie corpse-in falla i gegnum jordina, destroy-ar theim til ad leysa minni og baetir vid score
        isSinking = true;
        Destroy(gameObject, sinkSpeed);
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        ScoreManager.score += scoreValue;
    }
}
