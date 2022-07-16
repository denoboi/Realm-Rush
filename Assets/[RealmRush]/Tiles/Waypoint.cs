using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    Waypoint waypoint;
    [SerializeField] private Tower towerPrefab; /*tower scripti icindekileri kullanmak istiyoruz bank icin.
                                                  her tower kurdugumuzda paramiz azalacak*/
 
   

    [SerializeField] bool isPlaceable;

    /* Private kullaniyorduk isPlaceable'i ancak baska scriptten erismek icin public yapabiliriz ancak bu da cok isimize yaramaz cunku diger scriptlerin hepsinden hem okuyup hem duzenleyebiliriz. 
    Bir method yapabiliriz bir bool-return turunde bu da cok iyi degil cunku methoddan bir islem bekleriz normalde.
       o yuzden property yapacagiz, hem daha temiz  duracak. */
    public bool IsPlaceable { get { return isPlaceable; } } 

    
  

    void OnMouseDown()
    {


        if (isPlaceable)
        {
            
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position); //bunu yeni yapti dikkat cok guzel yontem
            
            isPlaceable = !isPlaced; //bunu tam anlamadim. ama instantiate ettikten sonra isPlaceable false olmasi gerekiyordu. 
        }
        
    }


}
