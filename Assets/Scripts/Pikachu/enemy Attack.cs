using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackDamage = 10f; // The amount of damage an attack does
    public float attackRate = 1f; // How often the enemy can attack in seconds
    public float attackRange = 3f; // The range within which the enemy can attack the player
    private float nextAttackTime = 0f; // When the enemy is allowed to attack again
    AudioSource PikaSound;

    // Reference to the player's stats
    private PlayerStats playerStats;

    private void Start()
    {
        // Find the player in the scene and get their PlayerStats component
        playerStats = GameObject.FindObjectOfType<PlayerStats>();
    }

    private void Update()
    {
        // If it's time to attack again and the player is in range, attack
        if (Time.time >= nextAttackTime && IsPlayerInRange())
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    private bool IsPlayerInRange()
    {
        // Check the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(playerStats.transform.position, transform.position);
        return distanceToPlayer <= attackRange;
    }

    private void Attack()
    {
        if (playerStats != null)
        {
            playerStats.TakeDamage((int)attackDamage);
        }
    }
}