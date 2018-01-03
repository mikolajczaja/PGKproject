using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
    public class ScoreManager : MonoBehaviour
    {
        public static int score;
        Text text;
        string initialText;

        void Awake()
        {
            text = GetComponent<Text>();
            initialText = text.text;
            score = 0;
        }


        void Update()
        {
            text.text = initialText + score;
        }
    }
}