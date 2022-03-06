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

    /* bu script textmeshpro'ya ait. Waypoint'e buradan ulasacagim ve isPlaceable olmayan yerleri silik hale getirecegim.
     * boylece oraya bir sey eklenmeyecegini gosterecegim gorsel olarak  */

    Waypoint waypoint;

    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();

        //waypoint textmeshpro'nun parenti oldugu icin 
        waypoint = GetComponentInParent<Waypoint>();
        
        //Runtime'da da calismasi icin
        DisplayCoordinates();
    }

    // Update is called once per frame
    void Update()
    {

        //Sadece edit mode'da gosteriyor.
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        ColorCoordinates();

    }


    //isPlaceable degilse rengi degistirecek.
    private void ColorCoordinates()
    {
        //HOCAYA SOR
        //switch()
        //{
        //    case waypoint.IsPlaceable:
        //            label.color = defaultColor;
        //        break;

        //}
       
        if(waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }

        else if(!waypoint.IsPlaceable)
        {
            label.color = blockedColor;
        }
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
