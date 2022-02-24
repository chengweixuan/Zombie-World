using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JillAI : MonoBehaviour
{
    public GameObject projectile;
    public int health;

    private bool isNearPlayer;
    private Animator anim;
    private AudioSource audioSource;

    public AudioClip attackSound1;
    public AudioClip attackSound2;
    public AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        isNearPlayer = false;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void DoDamage()
    {
        if (isNearPlayer)
        {
            GameManager.Instance.TakeDamage(10);
        }
    }

    void PlayAttackSound()
    {
        int randInt = Random.Range(1, 3);

        if (randInt == 1)
        {
            audioSource.clip = attackSound1;
        }
        else
        {
            audioSource.clip = attackSound2;
        }
        audioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearPlayer = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == projectile)
        {
            health -= 10;

            if (health <= 0)
            {
                StartCoroutine(Die());
            }
        }
    }

    IEnumerator Die()
    {
        Debug.Log("dead");
        anim.SetBool("isDead", true);
        audioSource.clip = deathSound;
        audioSource.Play();

        yield return new WaitForSeconds(6);
        Destroy(gameObject);
    }
}
