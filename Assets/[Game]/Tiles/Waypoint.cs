using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isPlaceable;
    Waypoint waypoint;
    public GameObject ballista;
   
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (isPlaceable)
        {
            Debug.Log(transform.name);
            Instantiate(ballista, transform.position, Quaternion.identity);
        }
        
    }
}
