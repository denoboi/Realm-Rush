using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMover : MonoBehaviour
{

    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {

        FindPath();
        StartCoroutine(FollowPath());


    }


    /* Normalde tag ile yapmiyorduk. Path'i elle veriyorduk. Simdi tag ile yaptigimiz icin bunlari bulacagiz array'de.
     * Daha sonra bunlari listemize ekleyecegiz FindPath methodu icinde. */

    void FindPath()
    {
        //guard statement(yani oncekini siliyor ve yeni ekliyor)
        path.Clear();

        //simdilik bu iyi bir yontem degil, cunku hangi sirayla alacagini bilmiyoruz. Yine elle vermemiz gerek. Ileride degisecek.
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");


        foreach (GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }
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
    }
}
