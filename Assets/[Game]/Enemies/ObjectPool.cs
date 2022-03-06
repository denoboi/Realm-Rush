using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;


    private void Start()
    {
        StartCoroutine(InstantiateEnemies());
    }
    

    /* Su an bu haliyle surekli obje spawn edip destroy ediyor. Bu yuzden object pool kullanacagim ileride */
    IEnumerator InstantiateEnemies()
    {
        int _enemyCount = 0;

        while(_enemyCount<6)
        {
            Instantiate(_enemyPrefab);
            _enemyCount++;
            yield return new WaitForSeconds(3);
        }

        
    }
}
