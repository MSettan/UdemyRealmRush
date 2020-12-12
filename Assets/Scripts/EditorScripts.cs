using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorScripts : MonoBehaviour
{

    [SerializeField] [Range(1f, 20f)] private int gridSize;
    // Update is called once per frame
    void Update()
    {
        
        Vector3 snapPos; ;
        var snapPosition = transform.position;
        
        snapPos.x = Mathf.RoundToInt(snapPosition.x / 10f) * gridSize;
        snapPos.z = Mathf.RoundToInt(snapPosition.z / 10f) * gridSize;
        
        snapPosition = new Vector3(snapPos.x, 0f, snapPos.z);
        transform.position = snapPosition;
    }
}
