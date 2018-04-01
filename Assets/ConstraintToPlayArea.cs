using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstraintToPlayArea : MonoBehaviour {
	public Renderer target;
	private float width;
	private float height;

	// Use this for initialization
	void Start () {		
		BoxCollider2D collider = GetComponent<BoxCollider2D> ();
		width = collider.bounds.max.x - collider.bounds.min.x;
		height = collider.bounds.max.y - collider.bounds.min.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, target.bounds.min.x, target.bounds.max.x - width),
			Mathf.Clamp (transform.position.y, target.bounds.min.y + (height / 2), target.bounds.max.y - (height / 2)),
			transform.position.z
		);
	}
}
