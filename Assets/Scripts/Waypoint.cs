using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // Start is called before the first frame update
    const int gridSize = 10;

    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;
    
    private Vector2Int gridPos;

    private void Start()
    {
        Physics.queriesHitTriggers = true;
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int
            (
            Mathf.RoundToInt(transform.position.x / 10f),
            Mathf.RoundToInt(transform.position.z / 10f)
            );
    }

     private void OnMouseOver()
     {
         if (Input.GetMouseButtonDown(0) && isPlaceable) 
         {
             print("This on " + gameObject.name);
         }
     }
     
}
