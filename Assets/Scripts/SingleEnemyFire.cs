using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleEnemyFire : MonoBehaviour
{

    public GameObject bullet;
    [SerializeField]
    float startDelay = 1f;

    [SerializeField] private float fireRate = 2f;
	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(FireLaser());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator FireLaser()
    {
        yield return new WaitForSeconds(startDelay + Random.Range(0, 1f));
        while (true)
        {
            GetComponent<EnemyMovement>().isMoving = false;
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z),
                Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
            GetComponent<EnemyMovement>().isMoving = true;
            //b.GetComponent<Rigidbody2D>().velocity = Vector2.down * ;
            yield return new WaitForSeconds(Random.Range(fireRate - 0.2f, fireRate + 0.2f));
        }
    }
}
