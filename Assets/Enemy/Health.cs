using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    [SerializeField] int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
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
            Destroy(gameObject);
        }
    }
}
