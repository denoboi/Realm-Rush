using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(requiredComponent: typeof(TextMeshPro))]
[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    /* bu script textmeshpro'ya ait. Waypoint'e buradan ulasacagim ve isPlaceable olmayan yerleri silik hale getirecegim.
     * boylece oraya bir sey eklenmeyecegini gosterecegim gorsel olarak  */

    Waypoint waypoint;

    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.red;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();

        label.enabled = true;

        //waypoint'e ulasmam gerek(isPlaceable olcmem icin) ve waypoint textmeshpro'nun parenti oldugu icin 
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
        ToggleLabels();




    }


    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            //
            label.enabled = !label.IsActive();
        }
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

        else
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
