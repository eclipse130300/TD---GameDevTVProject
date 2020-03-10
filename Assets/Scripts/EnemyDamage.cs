using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
	[SerializeField] int hitPoints = 10;
	// Use this for initialization

	void Update()
	{
		if(hitPoints <= 0)
		{
			DestroyEnemy();
		}
	}
	void OnParticleCollision(GameObject other)
	{
		print("I'm hit!!");
		hitPoints--;
	}
	void ProcessHit()
	{
		hitPoints = hitPoints - 1;
	}
	void DestroyEnemy()
	{
		Destroy(gameObject);
	}
}
