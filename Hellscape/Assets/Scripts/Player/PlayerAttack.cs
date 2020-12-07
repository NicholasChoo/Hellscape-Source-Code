using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    public CharacterObject character;

    public Animator animator;

    public static float startingHealth;
    public static float baseHealth;
    public static float health;
    public static float helmetHealth;
    public static float armourHealth;
    public static float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;

    void Start()
    {
        startingHealth = 100;
        baseHealth = startingHealth;
        health = startingHealth;
    }

    void Update()
    {
        if(character.swordEquipped == true)
        {
            if (timeBetweenAttack <= 0)
            {
                if (Input.GetMouseButton(0))
                {
                    for (int i = 0; i < character.Container.Count; i++)
                    {
                        if (character.Container[i].item.type.ToString() == "Sword")
                        {
                            timeBetweenAttack = character.Container[i].item.attackSpeed;
                            Attack(character.Container[i].item.attack);
                            break;
                        }
                    }
                }
            }
            else
            {
                timeBetweenAttack -= Time.deltaTime;
            }
        }

        if (character.helmetEquipped == true)
        {
            for (int i = 0; i < character.Container.Count; i++)
            {
                if (character.Container[i].item.type.ToString() == "Helmet")
                {
                    helmetHealth = character.Container[i].item.health;
                }
            }
        }
        else
        {
            helmetHealth = 0f;
        }

        if (character.armourEquipped == true)
        {
            for (int i = 0; i < character.Container.Count; i++)
            {
                if (character.Container[i].item.type.ToString() == "Armour")
                {
                    armourHealth = character.Container[i].item.health;
                }
            }
        }
        else
        {
            armourHealth = 0f;
        }

        health = baseHealth + helmetHealth + armourHealth;

        if (health <= 0)
        {
            SceneManager.LoadScene("DeathScene");
        }
    }

    private void Attack(float damage)
    {
        animator.SetTrigger("Attack");
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().EnemyTakeDamage(damage);
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        baseHealth -= damage;
        health -= damage;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
