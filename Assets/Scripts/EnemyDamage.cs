using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
	[SerializeField] int hitPoints = 10;
	[SerializeField] ParticleSystem onHitParticles;
	[SerializeField] ParticleSystem deathFX;
	EnemyMovement enemyMovement;
	// Use this for initialization

	void OnParticleCollision(GameObject other)
	{
		if (hitPoints <= 0)
		{
			DestroyEnemy();
		}
		ProcessHit();
	}
	void ProcessHit()
	{
		hitPoints = hitPoints - 1;
		onHitParticles.Play();
	}
	void DestroyEnemy()
	{
		var vfx = Instantiate(deathFX, transform.position, Quaternion.identity);
		vfx.Play();
		Destroy(gameObject);
		Destroy(vfx, 1f);
	}
}
