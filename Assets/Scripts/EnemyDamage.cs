using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
	[SerializeField] int hitPoints = 10;
	[SerializeField] ParticleSystem onHitParticles;
	[SerializeField] ParticleSystem deathFX;
	EnemyMovement enemyMovement;

	public AudioClip hitTaken;
	public AudioClip enemyExplodes;
	AudioSource aSource;
	// Use this for initialization
	void Start()
	{
		aSource = GetComponent<AudioSource>();
	}
	void OnParticleCollision(GameObject other)
	{
		ProcessHit();
		if (hitPoints <= 0)
		{
			DestroyEnemy();
		}
	}
	void ProcessHit()
	{
		hitPoints = hitPoints - 1;
		AudioSource.PlayClipAtPoint(hitTaken, Camera.main.transform.position);
		onHitParticles.Play();
	}
	void DestroyEnemy()
	{
		var vfx = Instantiate(deathFX, transform.position, Quaternion.identity);
		vfx.Play();
		float particleDestoyDelay = vfx.main.duration;
		AudioSource.PlayClipAtPoint(enemyExplodes, Camera.main.transform.position);
		Destroy(gameObject);
		Destroy(vfx.gameObject, particleDestoyDelay);
	}
}
