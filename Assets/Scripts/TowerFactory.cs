using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] private int towerLimit = 3;
    [SerializeField] private Tower towerPrefab;
    [SerializeField] private Transform towerParentTransform;

    static Queue<Tower> _towerQueue = new Queue<Tower>();
    public void AddTower(Waypoint baseWaypoint)
    {
        int numTowers = _towerQueue.Count;

        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    
    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);

        newTower.transform.parent = towerParentTransform;
        
        newTower.baseWaypoint = baseWaypoint;

        newTower.baseWaypoint.isPlaceable = false;
        
        //baseWaypoint.isPlaceable = false;
        _towerQueue.Enqueue(newTower);
    }
    private static void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var oldTower = _towerQueue.Dequeue();
        oldTower.baseWaypoint.isPlaceable = true; ;
        newBaseWaypoint.isPlaceable = false;
        oldTower.baseWaypoint = newBaseWaypoint;
        oldTower.transform.position = newBaseWaypoint.transform.position;
        _towerQueue.Enqueue(oldTower);
    }
    
}
