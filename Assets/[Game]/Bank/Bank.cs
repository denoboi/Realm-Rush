using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
   [SerializeField] private int _startingBalance = 150;

   [SerializeField] private int _currentBalance;

    public int CurrentBalance { get { return _currentBalance; } } //disaridan erismek icin property, ancak sadece cekebiliyor, duzenlemesini biz burada yapacagiz.

    private void Awake()
    {
        _currentBalance = _startingBalance;
    }

    private void OnEnable()
    {
        EventManager.OnDestroyEnemy.AddListener(() => DepositMoney(25));
        EventManager.OnEnemyWins.AddListener(() => WithdrawMoney(25));

       
        EventManager.OnTowerAdded.AddListener(() => WithdrawMoney(75)); 
    }

    private void OnDisable()
    {
        EventManager.OnDestroyEnemy.RemoveListener(() => DepositMoney(25));
        EventManager.OnEnemyWins.RemoveListener(() => WithdrawMoney(25));
        EventManager.OnTowerAdded.RemoveListener(() => WithdrawMoney(75));
    }

    public void DepositMoney(int amount)
    {
        _currentBalance += Mathf.Abs(amount); //negatif sayi da girse bunu positif alacak Absolute sayesinde.
    }

    public void WithdrawMoney(int amount)
    {
        
        
        _currentBalance -= Mathf.Abs(amount);
       
    }
}
