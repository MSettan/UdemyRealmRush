using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    private TextMesh textMesh;
    private Vector3 gridPos;
    private Waypoint waypoint;


// Update is called once per frame
    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    private void Start()
    {
        textMesh = GetComponentInChildren<TextMesh>();
    }

    void Update()
    {
       
        SnapToGrid();
        LabelUpdate();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3
        (
            waypoint.GetGridPos().x*gridSize, 
            0f,
            waypoint.GetGridPos().y*gridSize
            );
    }

    private void LabelUpdate()
    {
        int gridSize = waypoint.GetGridSize();
        string blockLabel = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;

        textMesh.text = blockLabel;
        gameObject.name = "CubePrefab (" + blockLabel + ")";
    }
}
