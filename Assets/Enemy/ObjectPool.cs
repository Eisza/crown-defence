using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int poolSize = 3;
    [SerializeField] int spwanInterval = 2;

    GameObject[] pool;
    // Start is called before the first frame update
    void Start()
    {
        PopulatePool();
        StartCoroutine(MakeEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0 ; i < pool.Length ; i++)
        {
            pool[i] = Instantiate(enemyPrefab, this.transform);
            pool[i].SetActive(false);
        }
    }

    IEnumerator MakeEnemy()
    {
        while(true)
        {
            EnableEnemy();

            yield return new WaitForSeconds(spwanInterval);
        }
    }

    void EnableEnemy()
    {
        for (int i = 0 ; i < pool.Length ; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
