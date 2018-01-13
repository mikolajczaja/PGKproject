using System.Collections;
using UnityEngine;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject enemy;                // The enemy prefab to be spawned.


        GameObject[] spawnPoints;
        public int randomRange = 5;

        private void Start()
        {
            spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
            StartCoroutine("instantiateEnemy");
        }


        private IEnumerator instantiateEnemy()
        {

            while ((playerHealth.currentHealth > 0f) && (playerHealth.currentHealth < 500f))
            {
                
                yield return new WaitForSecondsRealtime(Random.value * randomRange);
                Spawn();

                yield return null;
            }

            yield return null;
        }

        void Spawn()
        {
            // If the player has no health left...
            if (GroupEnemyManager.enemyCount >= GroupEnemyManager.enemyCountLimit)
            {
                print("cant spawn"+ GroupEnemyManager.enemyCount);
                return;
            }

            GroupEnemyManager.enemyCount++;
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation);
        }
    }
}