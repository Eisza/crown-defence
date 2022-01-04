using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    Enemy enemyScript;
    [SerializeField] int maxHealth = 5;
    [SerializeField] int currentHealth;
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
            enemyScript.Reward();
        }
    }
}
