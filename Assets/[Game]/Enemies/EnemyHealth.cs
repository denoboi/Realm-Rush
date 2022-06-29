
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPoints;

    Enemy Enemy;

    private void Start()
    {
        Enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    
   

    private void OnParticleCollision(GameObject other)
    {
        Hit();
    }

    void Hit()
    {
        Debug.Log("hit");
        currentHitPoints --;
        if (currentHitPoints <= 0)
        {
            //pool kullandigimiz icin destroy yerine setactive kullaniyoruz
            gameObject.SetActive(false);
            Enemy.GoldReward();
        }
    }
}
