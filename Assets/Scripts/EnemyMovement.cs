using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	private Pathfinder pathfinder;
	[SerializeField] float movementPeriod = 0.5f;
	[SerializeField] ParticleSystem enemyFinishParticles;
	List<WayPoint> path;
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
			yield return new WaitForSeconds(movementPeriod);
		}
		SelfDestruct();
	}
	void Update()
	{

	}
	public void SelfDestruct()
	{
		ParticleSystem finishPart = Instantiate(enemyFinishParticles, transform.position, Quaternion.identity);
		float duration = finishPart.main.duration;
		finishPart.Play();
		Destroy(finishPart.gameObject, duration);
		Destroy(gameObject);
	}
}
