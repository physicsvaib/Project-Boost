﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstracle_movement : MonoBehaviour {

    [SerializeField] Vector3 momentVector;
    [SerializeField] float timePeriod = 5f;
    [Range(-1 , 1)] [SerializeField] float momentFactor;
    // Use this for initialization
    Vector3 startingPos;
    Vector3 offset;


    void Start () {
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        offset = momentVector * momentFactor;
        transform.position = startingPos + offset;
        moveIt();   
	}


    void moveIt()
    {
        float cycle = Time.time / timePeriod;

        momentFactor = Mathf.Sin(Mathf.PI * 2 * cycle);

    }
}
