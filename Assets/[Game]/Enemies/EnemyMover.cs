using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMover : MonoBehaviour
{

    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    Enemy Enemy;


    private void Start()
    {
        Enemy = GetComponent<Enemy>();
    }
    // Objeleri pool'dan cekip enable disable yaptigimiz icin bunu kullaniyoruz(start yerine)
    void OnEnable()
    {
        //bunlarin sirasi onemli
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
        


    }


    /* Normalde tag ile yapmiyorduk. Path'i elle veriyorduk. Simdi tag ile yaptigimiz icin bunlari bulacagiz array'de.
     * Daha sonra bunlari listemize ekleyecegiz FindPath methodu icinde. */

    void FindPath()
    {
        //guard statement - oncekini siliyor ve yeni ekliyor
        path.Clear();

        //simdilik bu iyi bir yontem degil, cunku hangi sirayla alacagini bilmiyoruz. Yine elle vermemiz gerek. Ileride degisecek.
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");


        foreach (GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }
    }


    //Ilk path karesinden baslatacak. cunku pool'da sonunda kaliyor ve setactive kapatiyordu.
    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }


        }

        //path sonunda destroy et enemy'i
        //destroy yerine set active kapatiyoruz cunku pool kullaniyoruz
        
        gameObject.SetActive(false);
        Enemy.GoldPenalty();

    }
}
