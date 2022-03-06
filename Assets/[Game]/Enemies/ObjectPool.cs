using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] int poolSize = 5;

    //bu tum olusturulan objeleri tutan pool
    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }

    private void Start()
    {
        StartCoroutine(InstantiateEnemies());
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i<pool.Length; i++)
        {
            
            pool[i] = Instantiate(_enemyPrefab, transform);
            pool[i].SetActive(false);

        }
    }

    
   
    IEnumerator InstantiateEnemies()
    {
       

        while(true)
        {
            //oyun basinda dogrudan spawn edecegimiz method
            EnableObjectInPool();
            
            yield return new WaitForSeconds(3);
        }

        
    }

    private void EnableObjectInPool()
    {
        for(var i = 0; i<pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
           
        }
    }
}
