using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;
    private Transform t;
    private Rigidbody2D rb;
    private bool goRight;
    public bool isMoving = true;

	// Use this for initialization
	void Start ()
	{
	    t = GetComponent<Transform>();
	    goRight = !(t.position.x > 0);
	    rb = GetComponent<Rigidbody2D>();
	   // StartCoroutine(Move());
	}
	
	// Update is called once per frame
	void Update () {
	    if (!isMoving)
	    {
	        t.Translate(Vector3.zero);
	    }
	    else if (goRight)
	    {
	        t.Translate(Vector2.right * moveSpeed * Time.deltaTime);
	    }
        else { 
	        t.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
	    }
	    if (t.position.x >= 8.0f)
	    {
	        goRight = false;
	    }
        else if (t.position.x <= -8.5f)
	    {
	        goRight = true;
	    }
	}

    //IEnumerator Move()
    //{
    //    while (true)
    //    {
    //        if (goRight)
    //        {
    //            rb.velocity = Vector2.right * moveSpeed;
    //        }
    //        else
    //        {
    //            rb.velocity = Vector2.right * -1 * moveSpeed;
    //        }
    //    }
    //}
}
