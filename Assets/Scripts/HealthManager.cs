using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float health = 1f;

    private SpriteRenderer sr;
    
    public int multiplier;

    private Color c, transparent;
    private bool dieing = false;
	// Use this for initialization
	void Start ()
	{
	    sr = GetComponent<SpriteRenderer>();
        c = sr.color;
	    transparent = c;
	    transparent.a = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	    if (health <= 0 && !dieing)
	    {
	        //GetComponent<Animator>().SetBool("isDead" , true);
            Invoke("Dead", 0.01f);
            dieing = true;
            playerController.instance.playerScore += multiplier*10;
            if (multiplier >= 100)
            {
                playerController.instance.gameover = true;
                Time.timeScale = 0;
            }
        }
	}

    public void TakeDamage(float dmg)
    {
        StartCoroutine(Flash());
        health -= dmg;
        playerController.instance.playerScore += 10;
    }

    public float GetHP()
    {
        return health;
    }

    IEnumerator Flash()
    {
        sr.color = transparent;
        yield return  new WaitForSeconds(0.2f);
        sr.color = c;
        yield return  new WaitForSeconds(0.2f);
        sr.color = transparent;
        yield return new WaitForSeconds(0.2f);
        sr.color = c;
    }

    void Dead()
    {
        RandomDropper.instance.Drop(transform.position);
        Destroy(this.gameObject);
    }
}
