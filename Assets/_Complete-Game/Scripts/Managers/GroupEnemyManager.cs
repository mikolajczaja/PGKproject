using System.Collections;
using UnityEngine;

namespace CompleteProject
{
    public class GroupEnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject enemy;                // The enemy prefab to be spawned.

        GameObject[] spawnPoints;
        public int maxEnemyCount;
        public static int enemyCountLimit = 0;
        public static int enemyCount = 0;
        public int randomRange = 5;
        public int groupCount = 5;

        private void Awake()
        {
            enemyCount = 0;
        }

        private void Start()
        {
            enemyCountLimit = DifficultyManager.EnemyCountLimit;
            spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
            StartCoroutine("instantiateEnemy");
        }


        private IEnumerator instantiateEnemy()
        {

            while ((playerHealth.currentHealth > 0f) && (playerHealth.currentHealth < 500f))
            {
                yield return new WaitForSecondsRealtime(Random.value * randomRange);


                for (int i = 0; i < groupCount; i++)
                {
                    Spawn();
                    yield return new WaitForSecondsRealtime(1f);
                }
                yield return null;
            }

            yield return null;
        }


        void Spawn()
        {
            // If the player has no health left...
            if (GroupEnemyManager.enemyCount >= GroupEnemyManager.enemyCountLimit)
            {
                print("cant spawn group:" + GroupEnemyManager.enemyCount);
                return;
            }

            GroupEnemyManager.enemyCount++;
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation);
        }
    }
}