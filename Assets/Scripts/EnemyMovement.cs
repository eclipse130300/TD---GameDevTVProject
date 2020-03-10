using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	private Pathfinder pathfinder;
	// Use this for initialization
	void Start()
	{
		pathfinder = GameObject.FindObjectOfType<Pathfinder>();
		StartCoroutine(FollowPath(pathfinder.GetPath()));
	}

	IEnumerator FollowPath(List<WayPoint> path)
	{
		foreach (WayPoint waypt in path)
		{
			transform.position = waypt.transform.position;
			yield return new WaitForSeconds(2f);
		}
	}
}
