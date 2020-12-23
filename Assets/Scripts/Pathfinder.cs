using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    private Queue<Waypoint> _queue = new Queue<Waypoint>();
    private Waypoint _searchCenter;// the current serchCenter
    [SerializeField] private List<Waypoint> path;//todo make private

    [SerializeField] private Waypoint startWaypoint, endWaypoint;
    [SerializeField] private bool isRunning = true; //todo private
    
    public List<Waypoint> GetPath()
    {
        if (isRunning)
        {
            LoadBlocks();
            Pathfind();
            BreadthFirstSearch();
            CreatePath();
        }
        return path;
    }
    
    private Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.down, 
        Vector2Int.left, 
        Vector2Int.right, 
    };

    private void CreatePath()
    {
        path.Add(endWaypoint);
        SetAsPath(endWaypoint);
        
        Waypoint previous = endWaypoint.exploredFrom;

        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
            SetAsPath(previous);
        }

        SetAsPath(startWaypoint);
        
        path.Reverse();
    }

    void SetAsPath(Waypoint waypoint)
    {
        waypoint.isPlaceable = false;
        waypoint = endWaypoint.exploredFrom;
    }

    private void BreadthFirstSearch()
    {
        
    }

    private void Pathfind()
    {
        _queue.Enqueue(startWaypoint);

        while (_queue.Count > 0 && isRunning)
        {
            _searchCenter = _queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            _searchCenter.isExplored = true;
        }
    }

    private void HaltIfEndFound()
    {
        if (endWaypoint == _searchCenter)
        {
            isRunning = false;
            print("Searching waypoint was find");
        }
    }

    private void ExploreNeighbours()
    {
        if(!isRunning){return;}
        
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighboursCoordinates = _searchCenter.GetGridPos() + direction;
            
            try
            {
                Waypoint neighbour = grid[neighboursCoordinates];

                if (neighbour.isExplored || _queue.Contains(neighbour))
                {

                }
                else
                {
                    neighbour.exploredFrom = _searchCenter;
                    _queue.Enqueue(neighbour);
                    //print("Queueing: " + neighbour.name); todo delete this
                }

            }
            catch
            {
                //do nothing
            }
        }
    }

    private void LoadBlocks()   
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());
            if (isOverlapping)
            {
                Debug.Log("Skipping overlapping block");
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }

        }
    }
    
}
