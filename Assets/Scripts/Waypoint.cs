﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Vector3Int gridPos;
    const int gridSize = 10;
    public bool isSearched=false;
    public bool isObstacle = false;
    public Waypoint exploredFrom;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        print(gameObject.name);
    }
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x/gridSize),
        Mathf.RoundToInt(transform.position.z/gridSize)
        );
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public void SetTopColor(Color color)
    {
       MeshRenderer topMeshRenderer= transform.Find("Top").GetComponent<MeshRenderer>();

        topMeshRenderer.material.color = color;
    }

}
