using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Vector3Int gridPos;
    const int gridSize = 10;
    public bool isSearched=false;
    public bool isObstacle = false;
    public Waypoint exploredFrom;
    public bool isPath;

    TowerFactory towerFactory;


    void Start()
    {
        towerFactory = FindObjectOfType<TowerFactory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isPath)
            {
                Vector3 towerPos = SetTowerPosition();
                towerFactory.InstantiateOnCube(towerPos);
                //                print(gameObject.name + " clicked");
                isPath = true;
            }
        }

    }
    Vector3 SetTowerPosition()
    {
        float yOffset = 5f;
        Vector3 setPos = new Vector3(
        gameObject.transform.position.x,
        gameObject.transform.position.y + yOffset,
        gameObject.transform.position.z
        );
        return setPos;

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
