using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {
    public GameObject towerPrefab;
    public Transform towersParentTransform;
    public int towerLimit;

    public Queue<Tower> towers = new Queue<Tower>();

    public void AddTower(WayPoint baseWaypoint)
    {
        if (towers.Count < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void MoveExistingTower(WayPoint baseWaypoint)
    {
        Tower lastTowerinQueue = towers.Dequeue();
        lastTowerinQueue.currentWayPoint.isPlaceable = true;
        lastTowerinQueue.transform.position = baseWaypoint.transform.position;
        baseWaypoint.isPlaceable = false;
        towers.Enqueue(lastTowerinQueue);
        lastTowerinQueue.currentWayPoint = baseWaypoint;
    }

    private void InstantiateNewTower(WayPoint baseWaypoint)
    {
        GameObject towerCopy = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        towerCopy.transform.parent = towersParentTransform;
        Tower towerScript = towerCopy.GetComponent<Tower>();
        baseWaypoint.isPlaceable = false;
        towers.Enqueue(towerScript);
        towerScript.currentWayPoint = baseWaypoint;
    }
}
