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
        public static int finalScore;


        public void ReloadGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("New Scene");
        }

        void Awake()
        {
            text = GetComponent<Text>();
            text.text = "Game Over";
        }


        void Update()
        {
            
            if (TriggerManager.isInRange())
            {
                text.text = "Level Completed\n"+ScoreManager.score;
                finalScore = ScoreManager.score;
            }
        }
    }
}
