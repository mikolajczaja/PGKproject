using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    GameObject cube1;

    void Start()
    {
        cube1 = GetComponent<GameObject>();
        print("initialized: " + cube1.name);
        print(cube1.GetComponentInChildren<GameObject>());
    }

    void Update()
    {
        Vector3 cubePosition = cube1.gameObject.transform.position;

        cubePosition.x++;
        cube1.gameObject.transform.position = cubePosition;
        print(cubePosition);
    }
}
