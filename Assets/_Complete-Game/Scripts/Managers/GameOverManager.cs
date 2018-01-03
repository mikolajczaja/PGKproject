using UnityEngine;

namespace CompleteProject
{
    public class GameOverManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's health.
        public Transform player;
        public GameObject mapExit;

        Animator anim;                          // Reference to the animator component.


        void Awake ()
        {
            // Set up the reference.
            anim = GetComponent <Animator> ();
        }


        void Update ()
        {
            // If the player has run out of health...
            if((playerHealth.currentHealth <= 0)||(TriggerManager.isInRange()))
            {
                // ... tell the animator the game is over.
                anim.SetTrigger ("GameOver");
            }

        }
    }
}