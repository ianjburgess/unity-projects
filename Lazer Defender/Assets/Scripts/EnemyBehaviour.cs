using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
    public float health = 150f;
    public GameObject enemyAttack;
    public float enemyProjectileSpeed = 10f;
    public float firingRate = 0.5f;

    private void Update()
    {
        // Enemy Attack Pattern
        float probability = Time.deltaTime*firingRate;
        if (Random.value < probability)
        {
            Fire();
        }
    }

    // Enemy Basic Attack
    private void Fire() 
    {
        Vector3 offset = new Vector3(0, 0.6f, 0);
        var enemyAttackBasic = Instantiate(enemyAttack, transform.position-offset, Quaternion.identity) as GameObject;
        enemyAttackBasic.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -enemyProjectileSpeed, 0);
    }

    // Damage/Health Control
    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();

        if (missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}