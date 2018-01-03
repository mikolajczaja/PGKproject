using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour {

    private static bool inRange=false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static bool isInRange()
    {
        return inRange;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("collision");
        inRange = true;
    }
}
