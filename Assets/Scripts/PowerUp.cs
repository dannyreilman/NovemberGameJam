using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    public float fallSpeed;
    public int type;

    private bool dead = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.position += (fallSpeed * Time.deltaTime) * Vector3.down;	
	}

    public int GetPowerUpType()
    {
        return type;
    }

    //Disables the object from being grabbed again
    public void Grab()
    {
        dead = true;
        gameObject.SetActive(false);
    }

    public bool CanGrab()
    {
        return !dead;
    }
}
