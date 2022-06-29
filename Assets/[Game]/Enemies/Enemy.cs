using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    [SerializeField] private int _goldReward = 25;
    [SerializeField] private int _goldPenalty = 25;

    
    public void GoldReward()
    {
        EventManager.OnDestroyEnemy.Invoke();
    }

    public void GoldPenalty()
    {

    }


}
