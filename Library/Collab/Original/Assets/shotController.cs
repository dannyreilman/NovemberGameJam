using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotController : MonoBehaviour {

	float speed = 6.0f;

    [SerializeField] private float damage = 1f;
    [SerializeField] private int pierce = 1;

    private int hitCount = 0;
    // Use this for initialization
    void Start () {
		this.GetComponent<Rigidbody2D>().velocity = Vector3.up * speed;
		StartCoroutine("destroythis");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator destroythis()
	{
		yield return new WaitForSeconds(5.0f);
		Destroy(this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
    {
		Debug.Log("Collided");
        if (other.GetComponent<HealthManager>() != null)
        {
			Debug.Log("trying to kill");
            other.GetComponent<HealthManager>().TakeDamage(damage);
            ++hitCount;
            if(hitCount >= pierce)
            {
                Destroy(this.gameObject);
            }
        }
		else if (other.tag == "enemy")
        {
            ++hitCount;
            if (hitCount >= pierce)
            {
                Destroy(this.gameObject);
            }
            Destroy(other.gameObject);
		}
    }
}
