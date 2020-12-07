using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public float health;
    public int damage;
    public Transform enemy;
    public LayerMask layerWall;
    public LayerMask whatIsPlayer;
    public float detectRange;
    public float attackRange;

    private GameObject player;
    public Vector2 playerPosition;

    public float attackTime;
    public float attackCooldown;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        playerPosition = player.transform.position;

        RaycastHit2D hit;

        hit = Physics2D.Linecast(transform.position, player.transform.position, layerWall);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Wall"))
            {
                gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }
            else
            {
                gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                MoveAndAttack();
            }
        }
        else
        {
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            MoveAndAttack();
        }

        if (health <= 0)
        {
            GetComponent<EnemyDrop>().Drops();
            Destroy(gameObject);
        }
    }

    private void Attack()
    {
        Collider2D[] playersToDamage = Physics2D.OverlapCircleAll(enemy.position, attackRange, whatIsPlayer);
        for (int i = 0; i < playersToDamage.Length; i++)
        {
            playersToDamage[i].GetComponent<PlayerAttack>().PlayerTakeDamage(damage);
        }
    }

    public void EnemyTakeDamage(float damage)
    {
        if(health > 0)
        {
            health -= damage;
            animator.SetTrigger("Take Damage");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemy.position, detectRange);
        Gizmos.DrawWireSphere(enemy.position, attackRange);
    }

    void MoveAndAttack()
    {
        Collider2D[] inDetectRange = Physics2D.OverlapCircleAll(enemy.position, detectRange, whatIsPlayer);
        Collider2D[] inAttackRange = Physics2D.OverlapCircleAll(enemy.position, attackRange, whatIsPlayer);
        if (inDetectRange.Length >= 1 && inAttackRange.Length == 0)
        {
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, -1.2f), playerPosition, 5 * Time.deltaTime);
        }
        if (inAttackRange.Length >= 1)
        {
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            if (attackTime > 0)
            {
                attackTime -= Time.deltaTime;
            }
            else if (attackTime <= 0)
            {
                Attack();
                attackTime = attackCooldown;
            }
        }
    }
}
