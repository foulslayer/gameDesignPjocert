using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public int damage;
    private playerHealth playerHealth;  // Reference to the player's health script

    // Called when the script instance is initialized.
    void Start()
    {
        // Find the player's health script in the scene or on the player prefab.
        playerHealth = FindObjectOfType<playerHealth>();

        // Check if the playerHealth is not found.
        if (playerHealth == null)
        {
            Debug.LogWarning("PlayerHealth not found in the scene or on the player prefab.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}


/*
public class monsterDamage : MonoBehaviour
{
    public int damage;
    public playerHealth playerHealth;

   
   private void OnCollisionEnter2D(Collision2D collision)
   {
    if(collision.gameObject.tag == "Player")
    {
        playerHealth.TakeDamage(damage);
    }
   }
}*/
