using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRubbish : MonoBehaviour {
	public GameObject safeZone;
	public Vector3 position;
	public Vector3 scale;
	public AudioClip clip;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			AudioSource.PlayClipAtPoint(clip, transform.position);
			Instantiate (safeZone, transform.position + position, Quaternion.identity);
			Destroy (this.gameObject);
		}
	}
}
