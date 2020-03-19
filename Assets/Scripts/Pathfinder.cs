using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pathfinder : MonoBehaviour
{
    public WayPoint startWaypoint, endWaypoint;
    WayPoint searchCenter;
    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    Queue<WayPoint> queue = new Queue<WayPoint>();
    public List<WayPoint> path = new List<WayPoint>();
    private bool isRunning = true; // todo make private
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    // Use this for initialization
    void Awake()
    {
        CalculatePath();
    }

    private void CalculatePath()
    {
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
    }

    public List<WayPoint> GetPath()
    {
        return path;
    }

    private void CreatePath()
    {
        WayPoint currentWP = endWaypoint;
        SetAsPath(currentWP);
        while(!path.Contains(startWaypoint))
        {
            WayPoint previousWP = currentWP.exploredFrom;
            SetAsPath(previousWP);
            currentWP = previousWP;
        }
        path.Reverse();
    }
    private void SetAsPath(WayPoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceable = false;
    }
    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }

        // todo work-out path!
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;

                if(grid.ContainsKey(neighbourCoordinates))
                     {
                        QueueNewNeighbours(neighbourCoordinates);
                     }

        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        WayPoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            // do nothing
        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<WayPoint>();
        foreach (WayPoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }
}
