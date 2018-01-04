using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
    public class AmmoManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;
        PlayerShooting playerShooting;
        Text text;
        string initialText;

        void Awake()
        {
            text = GetComponent<Text>();
            initialText = text.text;
            playerShooting = playerHealth.GetComponentInChildren<PlayerShooting>();
        }


        void Update()
        {
            text.text = initialText + playerShooting.currentAmmo;
        }
    }
}