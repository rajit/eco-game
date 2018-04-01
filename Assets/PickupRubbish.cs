using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRubbish : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		print ("console");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {
		print ("OnTriggerEnter " + col);
		Destroy (this.gameObject);
	}
}
