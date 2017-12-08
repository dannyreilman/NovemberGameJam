using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidLaserFire : MonoBehaviour {
    public GameObject bullet;
    [SerializeField] float startDelay = 1f;

    [SerializeField] private float bulletSpeed = 5f;

    [SerializeField] private float fireRate = 10f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(FireLaser());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FireLaser()
    {
        yield return new WaitForSeconds(startDelay + Random.Range(0f,1f));
        while (true)
        {
            GetComponent<EnemyMovement>().isMoving = false;
            GameObject b1 = Instantiate(bullet,
                new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z),
                Quaternion.identity);
            b1.GetComponent<Rigidbody2D>().velocity = Vector3.down * bulletSpeed;
            yield return new WaitForSeconds(0.3f);
            var b2 = Instantiate(bullet,
                new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z),
                Quaternion.identity);
            b2.GetComponent<Rigidbody2D>().velocity = Vector3.down * bulletSpeed;
            yield return new WaitForSeconds(0.3f);
            var b3 = Instantiate(bullet,
                new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z),
                Quaternion.identity);
            b3.GetComponent<Rigidbody2D>().velocity =  Vector3.down * bulletSpeed;
            yield return new WaitForSeconds(0.15f);
            GetComponent<EnemyMovement>().isMoving = true;
            //b.GetComponent<Rigidbody2D>().velocity = Vector2.down * ;
            yield return new WaitForSeconds(Random.Range(fireRate - 1f, fireRate + 1f));
        }
    }
}