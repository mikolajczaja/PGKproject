using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreManager : MonoBehaviour {


    public Text text;
	// Use this for initialization
	void Start () {
        GameEndingManager.finalScore = GameEndingManager.finalScore + 100;
        text.text = text.text + GameEndingManager.finalScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
