using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
        }

    }

    private void DisplayCoordinates()
    {
        //bu script tile objesinin child'i oldugu icin transform.parent kullaniyoruz(TMP'nin uzerinde)
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z);

        label.text = coordinates.x + "," + coordinates.y;
    }
}
