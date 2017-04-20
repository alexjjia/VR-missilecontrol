using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Designates spawning for the enemy
 * */
public class EnemySpawner : MonoBehaviour {
	public GameObject enemy;

	private int minSpawnRadius; //minimum radius with which enemies can spawn from.
	private int maxSpawnRadius; //selects a radius with which enemies can spawn from.
	private float spawnDelay; //spawn delay between waves.
	private float spawnTimer; //used to figure out how much time has passed.

	// Use this for initialization
	void Start () {
		spawnTimer = Time.time + spawnDelay; //sets up the timer.
		minSpawnRadius = 10;
		maxSpawnRadius = 40;
		spawnDelay = 5.0f;	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > spawnTimer)
		{
			Vector3 enemySpawnPt = new Vector3 (Random.Range(minSpawnRadius, maxSpawnRadius), Random.Range(minSpawnRadius, maxSpawnRadius), Random.Range(minSpawnRadius, maxSpawnRadius));
			Instantiate (enemy, transform.position+enemySpawnPt, transform.rotation);
			spawnTimer = Time.time + spawnDelay;
		}
	}

	float calculateDistance(GameObject target)
	{
		return Mathf.Sqrt (Mathf.Pow(target.transform.position.x - transform.position.x, 2) + Mathf.Pow(target.transform.position.y - transform.position.y, 2) + Mathf.Pow(target.transform.position.z - transform.position.z, 2));
	}
}
