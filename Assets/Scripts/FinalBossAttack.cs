using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossAttack : MonoBehaviour {
    public GameObject[] bullets;
    private HealthManager hm;
    private int hp;
    [SerializeField] float startDelay = 1f;

    [SerializeField] private float bulletSpeed = 2f;

    [SerializeField] private float fireRate = 5f;
    void Start()
    {
        StartCoroutine(FireLaser());
        hm = GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        hp = Mathf.FloorToInt(hm.GetHP());
    }

    IEnumerator FireLaser()
    {
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            //phase 1
            GetComponent<EnemyMovement>().isMoving = false;
            if (hp > 100)
            {
                GameObject b1 = Instantiate(bullets[0],
                    new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z),
                    Quaternion.identity);
                GameObject b2 = Instantiate(bullets[0], new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z),
                    Quaternion.identity);
                GameObject b3 = Instantiate(bullets[0], new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z),
                    Quaternion.identity);
                yield return new WaitForSeconds(0.2f);
                GetComponent<EnemyMovement>().isMoving = true;
                yield return new WaitForSeconds(Random.Range(fireRate - 0.5f, fireRate));
            }
            //phase2
            else if (hp > 50)
            {
                GameObject b1 = Instantiate(bullets[0],
                    new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z),
                    Quaternion.identity);
                var b2 = Instantiate(bullets[1],
                    new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z),
                    Quaternion.identity);
                var b3 = Instantiate(bullets[1],
                    new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z),
                    Quaternion.identity);
                GameObject b4 = Instantiate(bullets[0],
                    new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z),
                    Quaternion.identity);
                b2.GetComponent<Rigidbody2D>().velocity = Vector3.down * bulletSpeed;
                GameObject b5 = Instantiate(bullets[0],
                    new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z),
                    Quaternion.identity);
                var b6 = Instantiate(bullets[1],
                    new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z),
                    Quaternion.identity);
                var b7 = Instantiate(bullets[1],
                    new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z),
                    Quaternion.identity);
                b2.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, -15) * Vector3.down * bulletSpeed * 2.5f;
                b3.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, 15) * Vector3.down * bulletSpeed * 2f;
                b6.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, -20) * Vector3.down * bulletSpeed * 2f;
                b7.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, 20) * Vector3.down * bulletSpeed * 2.5f;
                yield return new WaitForSeconds(0.2f);
                GetComponent<EnemyMovement>().isMoving = true;
                yield return new WaitForSeconds(Random.Range(fireRate - 3f, fireRate - 2f));
            }
            else
            {
                Instantiate(bullets[0],
                    new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z),
                    Quaternion.identity);
                Instantiate(bullets[0],
                    new Vector3(transform.position.x + 1f, transform.position.y - 1.5f, transform.position.z),
                    Quaternion.identity);
                Instantiate(bullets[0],
                    new Vector3(transform.position.x- 1f, transform.position.y - 1.5f, transform.position.z),
                    Quaternion.identity);
                GameObject b1 = Instantiate(bullets[2],
                    new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z),
                    Quaternion.identity);
                var b2 = Instantiate(bullets[1],
                    new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z),
                    Quaternion.identity);
                var b3 = Instantiate(bullets[1],
                    new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z),
                    Quaternion.identity);
                GameObject b4 = Instantiate(bullets[2],
                    new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z),
                    Quaternion.identity);
                b2.GetComponent<Rigidbody2D>().velocity = Vector3.down * bulletSpeed;
                GameObject b5 = Instantiate(bullets[2],
                    new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z),
                    Quaternion.identity);
                GameObject b6 = Instantiate(bullets[2], new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z),
                    Quaternion.identity);
                b6.GetComponent<Rigidbody2D>().velocity = Vector3.down * bulletSpeed * 3f;
                GameObject b7 = Instantiate(bullets[2], new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z),
                    Quaternion.identity);
                var b8 = Instantiate(bullets[1],
                    new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z),
                    Quaternion.identity);
                var b9 = Instantiate(bullets[1],
                    new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z),
                    Quaternion.identity);
                b7.GetComponent<Rigidbody2D>().velocity = Vector3.down * bulletSpeed * 3f;
                b1.GetComponent<Rigidbody2D>().velocity = Vector3.down * bulletSpeed * 3f;
                b2.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, -15) * Vector3.down * bulletSpeed * 3f;
                b3.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, 15) * Vector3.down * bulletSpeed * 3f;
                b8.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, -20) * Vector3.down * bulletSpeed * 3f;
                b9.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, 20) * Vector3.down * bulletSpeed * 3f;
                b4.GetComponent<Rigidbody2D>().velocity = Vector3.down * bulletSpeed * 3f;
                b5.GetComponent<Rigidbody2D>().velocity = Vector3.down * bulletSpeed * 3f;
                yield return new WaitForSeconds(0.33f);
                GameObject b10 = Instantiate(bullets[2],
                    new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z),
                    Quaternion.identity);
                GameObject b11 = Instantiate(bullets[2],
                    new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z),
                    Quaternion.identity);
                GameObject b12 = Instantiate(bullets[2],
                    new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z),
                    Quaternion.identity);
                b10.GetComponent<Rigidbody2D>().velocity = Vector3.down * bulletSpeed * 3f;
                b11.GetComponent<Rigidbody2D>().velocity = Vector3.down * bulletSpeed * 3f;
                b12.GetComponent<Rigidbody2D>().velocity = Vector3.down * bulletSpeed * 3f;

                GetComponent<EnemyMovement>().isMoving = true;
                yield return new WaitForSeconds(Random.Range(fireRate - 3f, fireRate - 2.5f));
            }
        }

        //phase 1

        //b.GetComponent<Rigidbody2D>().velocity = Vector2.down * ;
    }
}
