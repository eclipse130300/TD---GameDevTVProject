using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
	[SerializeField] Transform objectToPan;
	[SerializeField] float shootingDistance = 10f;
	ParticleSystem bullets;

	//GameObject[] enemies;
	GameObject targetEnemy;

	float enemyCheckTimer = 0.1f;
	float distanceToEnemy;
	void Start()
	{
		bullets = GetComponentInChildren<ParticleSystem>();
	}
	// Update is called once per frame
	void Update()
	{
		if (!targetEnemy)
		{
			FindTargetEnemy();
			ShootEnemy(false);
		}
		else
		{
			objectToPan.LookAt(targetEnemy.transform);
			ShootEnemy(true);
			if (Vector3.Distance(gameObject.transform.position, targetEnemy.transform.position) > shootingDistance)
			{
				targetEnemy = null;
			}
		}
	}

	void FindTargetEnemy()
	{
		var enemies = GameObject.FindObjectsOfType<EnemyDamage>();
		Transform closestEnemy = enemies[0].transform;
		foreach (EnemyDamage enemy in enemies)
		{
			closestEnemy = GetClosest(closestEnemy, enemy.transform);
		}
		targetEnemy = closestEnemy.gameObject;
	}

	private Transform GetClosest(Transform closestEnemy, Transform newTransform)
	{
		if(Vector3.Distance(transform.position, newTransform.position) <= (Vector3.Distance(transform.position, closestEnemy.position)))
		{
			return newTransform;
		}
		else
		{
			return closestEnemy;
		}
	}

	void ShootEnemy(bool isActive)
	{
		var emissionModule = bullets.emission;
		emissionModule.enabled = isActive;
	}
}
