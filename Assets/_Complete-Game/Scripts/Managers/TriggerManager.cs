using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour {

    private static bool inRange=false;

    private void Awake()
    {
        inRange = false;
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
