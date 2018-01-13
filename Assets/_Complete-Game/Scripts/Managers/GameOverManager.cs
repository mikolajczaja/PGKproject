using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CompleteProject
{
    public class GameOverManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;
        public Button restartButton;
        public Button exitButton;

        Animator animator;

        private void initializeButtons()
        {
            restartButton.enabled = true;
            print(restartButton.enabled);
            exitButton.enabled = true;
            print("initialized");
        }

        void Awake()
        {
            // Set up the reference.
            animator = GetComponent<Animator>();
        }


        void Update()
        {
            // If the player has run out of health...
            if (playerHealth.currentHealth <= 0)
            {
                // ... tell the animator the game is over.
                animator.SetTrigger("GameOver");

               // initializeButtons();
                SceneManager.LoadScene("Game Over");

                return;
            }
            if (TriggerManager.isInRange())
            {
                animator.SetTrigger("GameOver");

                // initializeButtons();
                SceneManager.LoadScene("Game Won");

                return;
            }
        }
    }
}