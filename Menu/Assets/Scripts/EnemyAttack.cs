using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
   
    public float timeBetweenAttacks;     // The time in seconds between each attack.
    public float attackDamage;               // The amount of health taken away per attack.

    public float dismax;
    GameObject player;                          // Reference to the player GameObject.
    PlayerController playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.

 
    void Update ()
    {
        timer += Time.deltaTime;
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerController> ();
        enemyHealth = GetComponent<EnemyHealth>();
       float dis = Vector3.Distance(transform.position, player.transform.position);
        if (dis < dismax)
        {
            playerInRange = true;
           
        }
        else
        {
            playerInRange = false;
        }
        if(enemyHealth.currentHealth > 0 && playerInRange && timer >= timeBetweenAttacks && SpellController.Stune == false)
        {
            Attack ();
        }
    }

    
    void Attack ()
    {
        timer = 0;
        if(playerHealth.Life > 0 )
        {
            attackDamage -= playerHealth.defence;
            if (SpellController.protection)
            {
                attackDamage = attackDamage - playerHealth.defenceS;
            }
            playerHealth.Life -= attackDamage;
        }
    }
}
