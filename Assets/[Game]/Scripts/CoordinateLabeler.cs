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
        //Runtime'da da calismasi icin
        DisplayCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
        }

        UpdateObjectName();

    }

    private void DisplayCoordinates()
    {
        /*bu script tile objesinin child'i oldugu icin transform.parent kullaniyoruz(TMP'nin uzerinde)
         ayni zamanda bunu snapsettings'e boluyoruz bu da 10'a boluyor */

        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinates.x + "," + coordinates.y;
    }

    private void UpdateObjectName()
    {
        //hierarchy'de update'lemesi icin

        transform.parent.name = coordinates.ToString();
    }
}
