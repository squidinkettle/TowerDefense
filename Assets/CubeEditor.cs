using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour
{

    TextMesh textmesh;
    [Range(1f, 20f)] [SerializeField] float gridSize;
    // Update is called once per frame
    void Start()
    {

    }
    void Update()
    {
        Vector3 snapPos;
        textmesh = GetComponentInChildren<TextMesh>();



        snapPos.x = Mathf.RoundToInt(transform.position.x/gridSize)* gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        string lableText = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        textmesh.text = lableText;
        gameObject.name = lableText;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
    }
}
