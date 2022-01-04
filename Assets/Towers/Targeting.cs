using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform turret;
    [SerializeField] ParticleSystem bolts;
    
    Transform target;

    [SerializeField] float range = 15f;


    // Update is called once per frame
    void Update()
    {
        FindNearestEnemy();

        aimWeapon();
    }

    void FindNearestEnemy()
    {

        Enemy[] enemies = FindObjectsOfType<Enemy>();

        Transform currentNearestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float currentDistance = Vector3.Distance(this.transform.position, enemy.transform.position);

            if( currentDistance <= maxDistance)
            {
                currentNearestTarget = enemy.transform;
                maxDistance = currentDistance;
            }
        }
        target = currentNearestTarget;
    }
    void aimWeapon()
    {
        if(target != null)
        {
            float distance = Vector3.Distance(this.transform.position, target.position);
            

            var emission = bolts.emission;

            if(distance <= range)
            {
                turret.LookAt(target);
                emission.enabled = true;
            }
            else{
                emission.enabled = false;
            }
        }
    }

}
