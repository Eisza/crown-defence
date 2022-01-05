using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class Health : MonoBehaviour
{

    Enemy enemyScript;
    [SerializeField] int maxHealth = 5;
    [Tooltip("Max health increase per respawn (accumulative)")]
    [SerializeField] int healthIncrease = 1;
    int currentHealth;
    void OnEnable()
    {
        currentHealth = maxHealth;
        enemyScript = FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void OnParticleCollision(GameObject other)
    {
        ProcessDamage();    
    }
        

    void ProcessDamage()
    {
        currentHealth -= 1;
        if(currentHealth <= 0){
            gameObject.SetActive(false);
            maxHealth += healthIncrease;
            enemyScript.Reward();
        }
    }
}
