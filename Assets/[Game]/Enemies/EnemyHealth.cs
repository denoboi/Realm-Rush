
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))] //bu enemy scripti ile birlikte gelecek.
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _maxHitPoints = 5;
    [SerializeField] int _currentHitPoints;
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] int _difficultyRamp = 2;

    private Enemy _enemy;

    
    private void Start()
    {
        
        _enemy = GetComponent<Enemy>(); /*burada null hatasi alabiliriz eger Enemy atamazsam,
        bu yuzden requireComponent yapacakmisiz. */ 
        
    }
    void OnEnable()
    {
        _currentHitPoints = _maxHitPoints;
    }

   
    private void OnParticleCollision(GameObject other)
    {
        Hit();
    }

    void Hit()
    {
        
        Debug.Log("hit");
       
        _currentHitPoints --;
        if (_currentHitPoints <= 0)
        {
            //pool kullandigimiz icin destroy yerine setactive kullaniyoruz
            gameObject.SetActive(false);
            _maxHitPoints += _difficultyRamp; //when enemy dies difficulty rise.
            _enemy.GoldReward();
        }
    }
}
