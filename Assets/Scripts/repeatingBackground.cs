using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatingBackground : MonoBehaviour {

	private float groundHorizontalLength;
	private Rigidbody2D rb;
	public bool stop = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(-1.5f, 0);
		groundHorizontalLength = 20.479f;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -groundHorizontalLength)
			repositionBG();
		if (stop)
		{
			rb.velocity = Vector2.down * 0.5f;
		}
	}

	private void repositionBG() {
		Vector2 groundOffset = new Vector2 (groundHorizontalLength, 0);
		transform.position = (Vector2) transform.position + groundOffset;
	}
}
