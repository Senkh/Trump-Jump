﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    private Rigidbody rb;
    private bool start = false;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        if(start)
            transform.Rotate(Vector3.forward * Time.deltaTime * 100);
        //transform.Rotate(Vector3.up * Time.deltaTime, Space.World);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            start = !start;
        }
    }
}