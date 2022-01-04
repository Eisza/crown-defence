using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;

    Bank bank;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    void Update()
    {
        
    }

    public void Reward()
    {
        bank.Deposit(goldReward);
    }

    public void Penalty()
    {
        bank.Withdraw(goldPenalty);
    }
}
