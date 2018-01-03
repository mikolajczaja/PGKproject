using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
    public class GameEndingManager : MonoBehaviour
    {
        Text text;
        public Transform player;
        public GameObject mapExit;

        void Awake()
        {
            text = GetComponent<Text>();
            text.text = "Game Over";
        }


        void Update()
        {
            
            if (TriggerManager.isInRange())
            {
                text.text = "Level Completed";
            }
        }
    }
}
