using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winOrLose : MonoBehaviour {
    public static bool won = false;
	private Image win;
    private Image lose;

    void Start()
    {
        win = transform.GetChild(0).GetComponent<Image>();
        lose = transform.GetChild(1).GetComponent<Image>();
    }


	// Update is called once per frame
	void Update ()
    {
		if(playerController.instance.health <= 0)
        {
            won = false;

            win.enabled = false;
			lose.enabled = true;
		}
		else
		{
            won = true;

            win.enabled = true;
			lose.enabled = false;
		}
	}
}
