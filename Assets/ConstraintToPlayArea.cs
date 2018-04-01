using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstraintToPlayArea : MonoBehaviour {
	public Renderer target;

	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, target.bounds.min.x, target.bounds.max.x),
			Mathf.Clamp (transform.position.y, target.bounds.min.y, target.bounds.max.y),
			transform.position.z
		);
	}
}
