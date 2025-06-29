using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour
{

    public int bulletDamage=20;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
     
        

        if (collision.gameObject.CompareTag("Target"))
        {
            print("hit " + collision.gameObject.name + " !");

            CreateBulletImpactEffect(collision);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            print("hit a wall!");
            CreateBulletImpactEffect(collision);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyScript>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Inamicu"))
        {
            collision.gameObject.GetComponent<EnemyScript>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }

    void CreateBulletImpactEffect(Collision objectWeHit)
    {
        ContactPoint contact = objectWeHit.contacts[0];
        GameObject hole = Instantiate(
           GlobalReferences.Instance.bulletImpactEffectPrefab, contact.point, Quaternion.LookRotation(contact.normal)
            );

        hole.transform.SetParent(objectWeHit.gameObject.transform);
    }
}