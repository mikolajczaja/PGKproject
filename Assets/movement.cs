using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position=Vector3.Lerp(transform.position, player.position, 0.001f);
        //transform.position = player.position;
       // print("en: " + transform.position + " , target: " + player.position);
	}
}
