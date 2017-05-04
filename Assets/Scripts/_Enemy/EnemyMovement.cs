﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour {
	Transform player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	NavMeshAgent nav;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent <EnemyHealth> ();
		nav = GetComponent <NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth.currentHealth > 0 && enemyHealth.currentHealth > 0) {
			nav.SetDestination (player.position);
		} else {
			nav.enabled = false;
		}

	}
}
