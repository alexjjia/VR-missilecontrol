using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	private GameObject target; //aka the player.
	private float moveSpeed;
	private float someValue; //a generic variable that indicates the minimum distance between an enemy and a target; used to recalculate enemy object's trajectory.

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");
		moveSpeed = 10.0f;
		someValue = 20.0f;
		aimAtPlayer ();
	} 
	
	// Update is called once per frame
	void Update () 
	{
		//if the enemy is too far away from the target, recalculate trajectory.
		if (calculateDistance (target) >= someValue)
		{
			aimAtPlayer ();
		}
		//otherwise, continue charging blindly at the player.
		chargeAtPlayer ();
	}

	//readjusts aim to be pointed at the player.
	void aimAtPlayer()
	{
		transform.LookAt (target.transform.position);
	}

	void chargeAtPlayer()
	{
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
	}

	float calculateDistance(GameObject target)
	{
		return Mathf.Sqrt (Mathf.Pow(target.transform.position.x - transform.position.x, 2) + Mathf.Pow(target.transform.position.y - transform.position.y, 2) + Mathf.Pow(target.transform.position.z - transform.position.z, 2));
	}
}
