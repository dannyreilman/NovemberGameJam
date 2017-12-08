using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGunModule : MonoBehaviour {
    static float minDelay = 1.0f;
    static float maxDelay = 2.0f;

    public GameObject projectile;
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        transform.rotation = Quaternion.Euler(0, 0, 0);
        StartCoroutine(FireRandomly());
	}


    private IEnumerator FireRandomly()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
            Fire();
        }
        
    }
    private void Fire()
    {
        if (!playerController.instance.isDead())
        {
            GameObject newShot = Instantiate(projectile, transform.position + new Vector3(0, 0.25f), transform.rotation) as GameObject;
            anim.SetTrigger("Fire");
        }
    }
}
