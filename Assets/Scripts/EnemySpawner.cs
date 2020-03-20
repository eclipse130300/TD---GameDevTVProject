using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
	[Range(0.1f, 120f)]
	[SerializeField] float secondsBetweenSpawns = 2;
	public Pathfinder pathfinderScript;
	[SerializeField] EnemyMovement enemy;
	public Transform enemiesParent;
	public AudioClip enemySpawnSFX;
	AudioSource audioSource;

	public Text ScoreText;
	static int score;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		StartCoroutine(SpawnEnemy());
		ScoreText.text = score.ToString();
	}
	
	// Update is called once per frame

	IEnumerator SpawnEnemy()
	{
		while (true)
		{
			var enemyCopy = Instantiate(enemy, pathfinderScript.startWaypoint.transform.position, Quaternion.identity);
			enemyCopy.transform.parent = enemiesParent;
			score++;
			ScoreText.text = score.ToString();
			audioSource.PlayOneShot(enemySpawnSFX);
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
	}
}
