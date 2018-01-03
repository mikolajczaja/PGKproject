using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
    public class HealthManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;
        Text text;
        string initialText;

        void Awake()
        {
            text = GetComponent<Text>();
            initialText = text.text;
        }


        void Update()
        {
            if (playerHealth.currentHealth < 0)
            {
                playerHealth.currentHealth = 0;
            }
            text.text = initialText + playerHealth.currentHealth;
        }
    }
}