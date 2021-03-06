﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRubbish : MonoBehaviour {
	public GameObject safeZone;
	private Vector3 position;
	public Vector3 scale;
	public AudioClip clip;

	// Use this for initialization
	void Start () {
		BoxCollider2D collider = safeZone.GetComponent<BoxCollider2D> ();
		position = collider.offset;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			AudioSource.PlayClipAtPoint(clip, transform.position);
			GameObject newObj = Instantiate (safeZone, transform.position + position, Quaternion.identity);
			Physics2D.IgnoreCollision (newObj.GetComponent<Collider2D>(), col, true);

			Pathfinder2D.Instance.RecalculateMap ();
			Destroy (this.gameObject);
		}
	}
}
