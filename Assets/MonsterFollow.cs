using System;
using UnityEngine;

public class MonsterFollow : MonoBehaviour
{
	public Transform target;
	public float damping = 1;
	public float lookAheadFactor = 3;
	public float lookAheadReturnSpeed = 0.5f;
	public float lookAheadMoveThreshold = 0.1f;

	private float m_OffsetZ;
	private Vector3 m_LastTargetPosition;
	private Vector3 m_CurrentVelocity;
	private Vector3 m_LookAheadPos;
//	private Rigidbody2D rb;
	private Vector3 previousPos;
	private AudioSource myAudio;

	// Use this for initialization
	void Start()
	{
		m_OffsetZ = (transform.position - target.position).z;
		transform.parent = null;
		myAudio = GetComponent<AudioSource> ();
//		rb = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		Vector3 vel = (transform.position - previousPos) / Time.deltaTime;
		if (vel.magnitude >= 1) {
			if (myAudio.mute) {
				myAudio.mute = false;
			}
		} else if (!myAudio.mute) {
			myAudio.mute = true;
		}
		previousPos = transform.position;
	}

	// FixedUpdate is called during physics update phase
	void FixedUpdate()
	{
		Vector3 aheadTargetPos = target.position + Vector3.forward * m_OffsetZ;
		Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);
		if (myAudio != null) {
			Vector3 distance = transform.position - target.position;
			myAudio.volume = (float) (1 * Math.Pow (5 / (Mathf.Clamp (distance.magnitude, 4, 9) - 4), 4));
		}

		transform.position = newPos;
//		rb.MovePosition (aheadTargetPos);
	}
}