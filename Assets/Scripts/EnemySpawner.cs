using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	float spawnTimer;
	public float secondsBetweenSpawns = 2;
	public Pathfinder pathfinderScript;
	public EnemyMovement enemy;
	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnEnemy());
	}
	
	// Update is called once per frame

	IEnumerator SpawnEnemy()
	{
		while (true)
		{
			Instantiate(enemy, pathfinderScript.startWaypoint.transform.position, Quaternion.identity);
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
	}
}
