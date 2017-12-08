using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rotator : MonoBehaviour {

	private bool faceUp = false;
	private bool facingUp = false;
	bool movingUp = false;
	public repeatingBackground rb; 

	public bool clicked = false;

	private float speed = 30.0f;

	private Quaternion initial;

	void Awake()
	{
		initial = transform.localRotation;
	faceUp = false;
	facingUp = false;
	movingUp = false;
	clicked = false;

	speed = 30.0f;
	}

	// Update is called once per frame
	void Update () {
		if(transform.localRotation.z - initial.z < 0.005f)
			facingUp = true;
		else 
			facingUp = false;
		if((faceUp && !facingUp) || !faceUp)
		{
			transform.Rotate (0,0,speed*Time.deltaTime); //rotates 50 degrees per second around z axis
		}
		if(Input.GetKeyDown("return") || clicked)
		{
			//transform.rotation = Quaternion.Euler(0, 0, 0);
			faceUp = true;
			speed = 120f;
		}
		if (movingUp)
		{
			transform.localRotation = initial;
		}
		if(facingUp && faceUp)
		{
			rb.stop = true;
			moveUp();
		}
	}

	private void moveUp()
	{
		this.GetComponent<Rigidbody2D>().velocity = Vector2.up * 75.0f;
		StartCoroutine("toNextScene");
		movingUp = true;
		//Fade Menu
		//Fade Screen after time
			//Change scene
	}

	IEnumerator toNextScene()
	{
		yield return new WaitForSeconds(3.0f);
        //3 is menu
		SceneManager.LoadScene(1);
	}
}
