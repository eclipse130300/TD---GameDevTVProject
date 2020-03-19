using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	[Range(0.1f, 120f)]
	[SerializeField] float secondsBetweenSpawns = 2;
	public Pathfinder pathfinderScript;
	[SerializeField] EnemyMovement enemy;
	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnEnemy());
	}
	
	// Update is called once per frame

	IEnumerator SpawnEnemy()
	{
		while (true)
		{
			var enemyCopy = Instantiate(enemy, pathfinderScript.startWaypoint.transform.position, Quaternion.identity);
			
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
	}
}
