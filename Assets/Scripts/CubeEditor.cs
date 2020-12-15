using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{

 
    Waypoint waypoint;

    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    // Update is called once per frame
    void Start()
    {

    }
    void Update()
    {
        SnapGridPosition();
        UpdateBlockLable();

    }


    private void SnapGridPosition()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(
            waypoint.GetGridPos().x*gridSize,
             0f, 
            waypoint.GetGridPos().y*gridSize);

    }
    private void UpdateBlockLable()
    {
        TextMesh textmesh;
        textmesh = GetComponentInChildren<TextMesh>();

        int gridSize = waypoint.GetGridSize();
        string lableText = 
        waypoint.GetGridPos().x+
             "," + 
        waypoint.GetGridPos().y;

        textmesh.text = lableText;
        gameObject.name = lableText;
    }

}
