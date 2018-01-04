using UnityEngine;

namespace CompleteProject
{
    public class PickupManager : MonoBehaviour
    {

        AudioSource audioSource;
        public AudioClip audioClip;

        public PlayerHealth playerHealth;
        public PlayerShooting playerShooting;

        public int pickupHealthValue;
        public int pickupAmmoValue;

        // Use this for initialization
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioClip;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            audioSource.Play();
            playerHealth.currentHealth += pickupHealthValue;
            playerShooting.currentAmmo += pickupAmmoValue;

            Destroy(gameObject);
        }
    }
}
