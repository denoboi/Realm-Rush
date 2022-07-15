using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    
    [SerializeField] Transform weapon;
    //range gerek cok uzaga atiyorlar.
    [SerializeField] private float _range = 15f;

    //turning on/off particles
    [SerializeField] ParticleSystem _projectileParticles;
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
            //Vector3'un distance metodu tam aradigimiz, iki vektor arasindaki uzakligi veriyor.
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position); 
            
            //simdi elimizde maxdistance ve target distance oldugu icin bunlari kiyaslayip karsimizdaki dusman maxdistance'tan yakinsa onu bulacagiz yani closest olani :
            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                //simdi de her defasinda maxdistance'i currentdistance'a esitleyip yeni bir enemy daha yakindaysa ona odaklatacagiz.
                maxDistance = targetDistance;

            }
        }

        //target'i bulmak icin yukarida bir suru hesaplama yaptik, simdi asagida da target'i kullaniyorum en yakindakine aim almasi icin.
        target = closestTarget;
    }

    //burada objeye kitleniyor ancak sadece birine kitleniyor. En yakinindaki objeye kitlenip ates etmesi icin farkli bir sey yapmaliyiz. Onu da FindClosestEnemy metodunda yapacagiz.
    private void AimWeapon()
    {

        float targetDistance = Vector3.Distance(transform.position, target.position);

        //ates etmesek bile surekli target'a bakacak ancak range az ise ates etmeyecek(yani particle gondermeyecek)
        weapon.LookAt(target);

        if (targetDistance < _range)
        
            Attack(true);
        
        else
            Attack(false);
    }

    //Eger ates ediyorsa o zaman particle oynatacak.
    private void Attack(bool isActive)
    {
      var emmisionModule = _projectileParticles.emission;
          emmisionModule.enabled = isActive;
    }
}
