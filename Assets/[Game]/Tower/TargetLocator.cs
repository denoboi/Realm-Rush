using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target;
  
    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }


    void Update()
    {
        FindClosestEnemy();
        AimWeapon();
    }

    //This will scan every enemy on the scene and find the closest target by comparing their distances.
    private void FindClosestEnemy()
    {
        //Hepsini bulmak icin yeni olusturdugum bos enemy scriptini kullaniyorum.
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        //en yakindakini bulmak icin transform kullaniyorum simdilik null cunku daha bulamadik.
        Transform closestTarget = null;

        //en uzak distance tutacagiz tum enemy'lerin. bu yeni enemy eskisinden yakinsa onu bulmamiza yarayacak. En buyuk sayi da Infinity.  
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            //Vector3'un distance metodu tam aradigimiz iki vektor arasindaki uzakligi veriyor.
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
        }
    }

    //burada objeye kitleniyor ancak sadece birine kitleniyor. En yakinindaki objeye kitlenip ates etmesi icin farkli bir sey yapmaliyiz. Onu da FindClosestEnemy metodunda yapacagiz.
    private void AimWeapon()
    {
        weapon.LookAt(target);
    }

    private void FireWeapon()
    {
        
    }
}
