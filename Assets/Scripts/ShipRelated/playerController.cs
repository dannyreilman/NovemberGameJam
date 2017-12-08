using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playerController : MonoBehaviour {
    public static bool cinematic = false;
    public static playerController instance = null;
    private SpriteRenderer sr;
    private AudioSource audio;
	public int health = 5;
	bool dead = false;

    public bool gameover = false;

	float speed = 10.0f;

	public Text deadText;
    public int playerScore = 0;

    public Text score;
    public Text lives;

    public GameObject inGame;
    public GameObject postGame;

    public GameObject bullet;
	private GameObject newShot;
	private float shotInterval = 0.5f;

    private bool invulnerable = false;
	bool canShoot = true;

	private Rigidbody2D rb;

	void Awake()
	{        
		if (instance == null || instance.Equals(null))
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
		rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
        audio = this.GetComponent<AudioSource>();
        postGame.GetComponent<Canvas>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () 
	{
        lives.text = "x " + health.ToString();
        score.text = playerScore.ToString();
        rb.isKinematic = cinematic;
        if (!cinematic)
        {
            if (dead || gameover)
            {
                //Debug.Log("dead af");
                Time.timeScale = 0;
                inGame.GetComponent<Canvas>().enabled = false;
                postGame.GetComponent<Canvas>().enabled = true;
                if (Input.GetKeyDown("return"))
                {
                    dead = false;
                    gameObject.GetComponent<Renderer>().material.color = Color.white;
                    health = 3;
                }
            }
            movePlayer();
            shoot();
        }
	}

    public void TakeDamage(Collider2D other)
    {
        if (!cinematic)
        {
            //Debug.Log("Hit");

            Destroy(other.gameObject);
            if (!invulnerable)
            {
                audio.Play();

                health -= 1;
                if (health == 0)
                {
                    dead = true;
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    canShoot = false;
                }
                else
                {
                    ScreenShake.instance.Shake();
                    StartCoroutine(PainFlash());
                    StartCoroutine(Iframes());
                }
            }
        }

    }

    private IEnumerator Iframes()
    {
        invulnerable = true;
        yield return new WaitForSeconds(0.75f);
        invulnerable = false;
    }
    private IEnumerator PainFlash()
    {
        Time.timeScale = 0;
        Color original = sr.color;
        Color transparent = sr.color;
        transparent.a = 0;

        for (int i = 0; i < 3; ++i)
        {
            sr.color = transparent;
            yield return new WaitForSecondsRealtime(0.02f);
            sr.color = original;
            yield return new WaitForSecondsRealtime(0.01f);
        }

        if (!dead)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

	private void movePlayer()
	{
		float xAxis = Input.GetAxis("Horizontal");
		float yAxis = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(xAxis, yAxis);
		rb.velocity = (movement * speed);
	}

	private void shoot()
	{
		if ((Input.GetButton("Fire1") || Input.GetKey("space")) && canShoot)
        {
            generateBullets();
			StartCoroutine("nextShot");
        }
	}

	void generateBullets()
	{
		float offset = 0.46f;
		newShot = Instantiate(bullet, transform.position + new Vector3(offset, -0.1f), transform.rotation) as GameObject;
		newShot = Instantiate(bullet, transform.position + new Vector3(-offset, -0.1f), transform.rotation) as GameObject;		
	}

	private IEnumerator nextShot()
	{
		canShoot = false;
		yield return new WaitForSeconds(shotInterval);
		canShoot = true;
	}

    public bool isDead()
    {
        return dead;
    }
}
