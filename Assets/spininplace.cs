﻿using UnityEngine;
using System.Collections;

public class spininplace : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 10);
	}
}
