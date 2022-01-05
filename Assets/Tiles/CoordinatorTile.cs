using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
[ExecuteAlways]
public class CoordinatorTile : MonoBehaviour
{

    TextMeshPro label ;
    Waypoint waypoint;
    Vector2Int coordinates = new Vector2Int();
    //////////////

    void Awake()
    {
        waypoint = GetComponentInParent<Waypoint>();
        label = GetComponent<TextMeshPro>();

        DisplayCoordinates();
    }

    //////////////////
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        CoordinateColor();

        ToggleLabels();
    }

    void CoordinateColor()
    {
        if (!waypoint.IsPlaceable)
        {
            label.color = Color.grey;
        }
    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C)) {
            label.enabled = !label.enabled;
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = $"{coordinates.x},{coordinates.y}";
    }

    void UpdateObjectName()
    {
        transform.parent.name = $"({coordinates.x},{coordinates.y})";
    }




}
