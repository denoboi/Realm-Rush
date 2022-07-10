using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] int cost = 75;
   
    public bool CreateTower(Tower tower, Vector3 position) //bunu waypointte cagiriyor yonteme dikkat.
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null) return false;
       
        if(bank.CurrentBalance >= cost)
        {

            Instantiate(tower, position, Quaternion.identity);
            EventManager.OnTowerAdded.Invoke();
            return true; //bool yapiyor cunku bankada para yokken false yapacagiz.
        }

        return false; //tumunu saglayamazsa her turlu false donsun.
    }
}
