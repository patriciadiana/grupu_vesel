using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    private Animator animator;
    public GameObject character;

    private NavMeshAgent navAgent;
    [SerializeField] private AudioClip damageSoundClip;
    [SerializeField] private AudioClip dyingSoundClip;
    private void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            int randomValue = Random.Range(0, 2);
            SoundFXManager.instance.PlaySoundFXClip(dyingSoundClip, transform, 1f);

            if (randomValue == 0)
            {
                animator.SetTrigger("DIE1");
                if (character.gameObject.CompareTag("Inamicu"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
            else if(randomValue == 1)
            {
                animator.SetTrigger("DIE2");
                if (character.gameObject.CompareTag("Inamicu"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
        else
        {
            SoundFXManager.instance.PlaySoundFXClip(damageSoundClip, transform, 1f);
            animator.SetTrigger("DAMAGE");
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2.5f);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 10f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 12f);
    }

}
