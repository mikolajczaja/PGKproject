﻿using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        public Transform player;               // Reference to the player's position.
        public Vector3 playerPos;
        PlayerHealth playerHealth;      // Reference to the player's health.
        EnemyHealth enemyHealth;        // Reference to this enemy's health.
        UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.

        Rigidbody playerRigidbody;

        Vector3 destination;

        void Awake ()
        {
            // Set up the references.
            player = GameObject.FindGameObjectWithTag ("Player").transform;
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent <EnemyHealth> ();
            nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
            nav.Warp(new Vector3(0,0,0));
            destination = nav.destination;
        }

        Vector3 movement;

        void Update ()
        {

            playerPos = player.position;

            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {

                nav.destination = new Vector3(player.position.x, player.position.y, player.position.z);

            }

            else
            {
                nav.enabled = false;
            }
        }
    }
}