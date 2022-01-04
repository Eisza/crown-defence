using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    Bank bank;
    [SerializeField] int cost = 75;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool BuildTower(Vector3 position)
    {
        bank = FindObjectOfType<Bank>();
        if(bank == null)
        {
            return false;
        }
        else if(cost <= bank.CurrentBalance)
        {
            bank.Withdraw(cost);
            Instantiate(this.gameObject, position , Quaternion.identity);
            return true;
        }
        else{
            return false;
        }
        
    }
}
