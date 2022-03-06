using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    Waypoint waypoint;
    public GameObject towerPrefab;



    [SerializeField] bool isPlaceable;

    /* Private kullaniyorduk isPlaceable'i ancak baska scriptten erismek icin public yapabiliriz ancak bu da cok isimize yaramaz cunku diger scriptlerin hepsinden hem okuyup hem duzenleyebiliriz. 
    Bir method yapabiliriz bir bool-return turunde bu da cok iyi degil cunku methoddan bir islem bekleriz normalde.
       o yuzden property yapacagiz, hem daha temiz  duracak. */
    public bool IsPlaceable { get { return isPlaceable; } } //ilkinin buyuk harfli olduguna dikkat!

   
  

    void OnMouseDown()
    {
        if (isPlaceable)
        {
            Debug.Log(transform.name);
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
        
    }
}
