using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killProjectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("killAfterX");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator killAfterX()
	{
		yield return new WaitForSeconds(5.0f);
		Destroy(this.gameObject);
	}
}
