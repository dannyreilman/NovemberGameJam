using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayStars : MonoBehaviour {

	public Image star1;
	public Image star2;
	public Image star3;

	// Update is called once per frame
	void Update () {
		if (playerController.instance.playerScore < 500)
		{
			star1.enabled = false;
			star2.enabled = false;
			star3.enabled = false;
		}
		else if (playerController.instance.playerScore < 2000 && playerController.instance.playerScore > 500)
		{
			star1.enabled = true;
			star2.enabled = false;
			star3.enabled = false;
		}
		else if (playerController.instance.playerScore < 6000 && playerController.instance.playerScore > 2000)
		{
			star1.enabled = true;
			star2.enabled = true;
			star3.enabled = false;
		}
		else if (playerController.instance.playerScore > 6000)
		{
			star1.enabled = true;
			star2.enabled = true;
			star3.enabled = true;
		}
	}
}
