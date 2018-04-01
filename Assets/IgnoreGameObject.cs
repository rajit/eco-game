using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreGameObject : MonoBehaviour {
	public Collider2D objectToIgnore;

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreCollision (GetComponent<Collider2D>(), objectToIgnore, true);
	}
}
