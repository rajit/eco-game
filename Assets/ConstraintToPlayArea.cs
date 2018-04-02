using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstraintToPlayArea : MonoBehaviour {
	public Renderer target;
	private float minX;
	private float maxX;
	private float minY;
	private float maxY;
	private BoxCollider2D myCollider;

	// Use this for initialization
	void Start () {		
		myCollider = GetComponent<BoxCollider2D> ();
		float halfHeight = myCollider.size.y / 2;
		float halfWidth = myCollider.size.x / 2;
		minY = target.bounds.min.y + halfHeight - myCollider.offset.y;
		maxY = target.bounds.max.y - halfHeight - myCollider.offset.y;
		minX = target.bounds.min.x + halfWidth - myCollider.offset.x;
		maxX = target.bounds.max.x - halfWidth - myCollider.offset.x;
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, minX, maxX),
			Mathf.Clamp (transform.position.y, minY, maxY),
			transform.position.z
		);
	}
}
